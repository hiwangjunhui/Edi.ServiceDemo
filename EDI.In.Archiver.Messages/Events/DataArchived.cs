using NServiceBus;
using System;

namespace EDI.In.Archiver.Messages.Events
{
    public class DataArchived : IEvent
    {
        public Guid Id { get; set; }
    }
}
