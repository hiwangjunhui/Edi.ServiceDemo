using System;
using System.Collections.Generic;
using System.Text;

namespace EDI.In.Poller.Messages.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }

        public int Count { get; set; }
    }
}
