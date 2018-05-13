using System;

namespace Events.Api.Models
{
    public class CustomerEvent
    {
        public Guid CustomerId { get; set; }
        public Guid EventId { get; set; }
    }
}
