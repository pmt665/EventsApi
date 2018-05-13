using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Events.Api.Models
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public DateTime EventCreateDate { get; set; }
        public DateTime EventEndDate { get; set; }
    }
}
