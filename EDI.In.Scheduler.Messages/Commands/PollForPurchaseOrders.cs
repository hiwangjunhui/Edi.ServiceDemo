using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDI.In.Scheduler.Messages.Commands
{
    public class PollForPurchaseOrders : ICommand
    {
        public Guid Id { get; set; }
    }
}
