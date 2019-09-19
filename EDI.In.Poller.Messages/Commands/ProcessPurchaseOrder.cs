using EDI.In.Poller.Messages.Models;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDI.In.Poller.Messages.Commands
{
    public class ProcessPurchaseOrder : ICommand
    {
        public Guid Id { get; set; }

        public IEnumerable<Order> Orders { get; set; }
    }
}
