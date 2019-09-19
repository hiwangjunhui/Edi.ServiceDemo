using System;
using System.Collections.Generic;
using System.Text;
using NServiceBus;
using System.Threading.Tasks;
using EDI.In.Orchestrator.Resources;
using EDI.In.Poller.Messages.Commands;
using EDI.In.Orchestrator.Messages.Policies;
using EDI.In.Orchestrator.Helpers;
using EDI.In.Orchestrator.Endpoints;
using NServiceBus.Logging;
using EDI.In.Orchestrator.Messages.Commands;
using EDI.In.Archiver.Messages.Events;

namespace EDI.In.Orchestrator.Handlers
{
    public class Saga : Saga<State>, 
        IAmStartedByMessages<ProcessPurchaseOrder>,
        IHandleMessages<DataArchived>,
        IHandleTimeouts<IntegrationWarningPolicy>
    {
        private ILog _logger = LogManager.GetLogger<Saga>();

        public async Task Handle(ProcessPurchaseOrder message, IMessageHandlerContext context)
        {
            _logger.Info($"{message.Id} stated.");
            ushort minutes;
            var setting = Configuration.Root["SagaRequestTimeoutMinutes"];
            if (!ushort.TryParse(setting, out minutes)) minutes = 2;
            var policy = new IntegrationWarningPolicy { Id = message.Id, TimeoutMinutes = minutes };
            await RequestTimeout(context, TimeSpan.FromMinutes(policy.TimeoutMinutes), policy);
            var command = new ArchiveData { Id = message.Id, Orders = message.Orders };
            await context.Send(command);
        }

        public Task Handle(DataArchived message, IMessageHandlerContext context)
        {
            _logger.Info($"{message.Id} completed.");
            MarkAsComplete();
            return Task.CompletedTask;
        }

        public Task Timeout(IntegrationWarningPolicy state, IMessageHandlerContext context)
        {
            _logger.InfoFormat(ErrorMessage.SagaTimeoutMessage, state.Id, state.TimeoutMinutes);
            MarkAsComplete();
            return Task.CompletedTask;
        }

        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<State> mapper)
        {
            mapper.ConfigureMapping<ProcessPurchaseOrder>(t => t.Id).ToSaga(t => t.ProcessId);
            mapper.ConfigureMapping<DataArchived>(t => t.Id).ToSaga(t => t.ProcessId);
        }
    }
}
