using System;

namespace Events.Api.Models
{
    public class EventDetail
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Foregin key of the Events table
        /// </summary>
        public Guid EventId { get; set; }
        public string Description { get; set; }
    }
}
