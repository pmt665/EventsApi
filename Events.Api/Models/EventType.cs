using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Events.Api.Models
{
    public class EventType
    {
        /// <summary>
        /// Primary key 
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Event Type like TransactionEvent and CustomEvent.
        /// </summary>
        public string Type { get; set; }
    }
}
