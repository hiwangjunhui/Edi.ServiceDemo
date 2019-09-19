using EDI.In.Poller.Endpoints;
using EDI.In.Poller.Helpers;
using EDI.In.Poller.Messages.Commands;
using EDI.In.Poller.Messages.Models;
using EDI.In.Poller.Repositories;
using EDI.In.Scheduler.Messages.Commands;
using NServiceBus;
using NServiceBus.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDI.In.Poller.Handlers
{
    class PollForPurchaseOrdersHandler : IHandleMessages<PollForPurchaseOrders>
    {
        private ILog _logger = LogManager.GetLogger<PollForPurchaseOrdersHandler>();

        private static string _connectionString;
        private static string OrderDbConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    var setting = Configuration.GetSetting<Setting>();
                    _connectionString = setting.PurchaseOrderConnection;
                }

                return _connectionString;
            }
        }

        public async Task Handle(PollForPurchaseOrders message, IMessageHandlerContext context)
        {
            DoValidateMessage(message);
            var orders = await GetOrders();
            var command = new ProcessPurchaseOrder { Id = message.Id, Orders = orders };
            await context.Send(command).ConfigureAwait(false);

            _logger.InfoFormat(Resources.LoggerMessage.PurchaseOrdersPolledMessage, orders.Count(), command.Id);
        }

        private async Task<IEnumerable<Order>> GetOrders()
        {
            using (var db = new DBHelper(OrderDbConnectionString))
            {
                return await Task.Run(() => db.Orders.ToList());
            }
        }

        private void DoValidateMessage(PollForPurchaseOrders message)
        {
            if (message.Id == default)
            {
                throw new System.Exception(Resources.ErrorMessage.IdOfPollForPurchaseOrdersNullMessage);
            }
        }
    }
}
