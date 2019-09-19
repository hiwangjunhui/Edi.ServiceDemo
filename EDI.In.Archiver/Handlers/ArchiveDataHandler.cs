using EDI.In.Archiver.Messages.Events;
using EDI.In.Orchestrator.Messages.Commands;
using EDI.In.Poller.Messages.Models;
using NServiceBus;
using NServiceBus.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace EDI.In.Archiver.Handlers
{
    public class ArchiveDataHandler : IHandleMessages<ArchiveData>
    {
        private ILog _logger = LogManager.GetLogger<ArchiveDataHandler>();
        private readonly Repositories.IDbHelper _dbHelper;

        public ArchiveDataHandler()
        {
            _dbHelper = null;
        }

        public async Task Handle(ArchiveData message, IMessageHandlerContext context)
        {
            _logger.Info($"{message.Orders.Count()} purcharse orders archived in this process {message.Id}");

            if (null != _dbHelper)
            {
                await _dbHelper.Insert(message.Orders);
            }

            var @event = new DataArchived { Id = message.Id };
            await context.Publish(@event);
        }
    }
}
