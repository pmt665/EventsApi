using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Events.Api.Models
{
    public class Customer
    {
        /// <summary>
        /// Primary key of the customer
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Name of the customer
        /// </summary>
        public string Name { get; set; }
    }
}
