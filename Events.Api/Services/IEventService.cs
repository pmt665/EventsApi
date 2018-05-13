using Events.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Events.Api.Services
{
    public interface IEventService
    {
        IEnumerable<Event> GetEvents();
        IEnumerable<EventType> GetEventTypes();
        IEnumerable<Customer> GetCustomers();
        IEnumerable<Event> GetEventsForCustomer(Guid id);
        IEnumerable<Event> GetEventsForCustomerByType(Guid id, string type, bool isAllSelected);
        IEnumerable<Event> GetEventsForCustomerByDate(Guid id, DateTime startDate, DateTime endDate, bool isAllSelected);
        EventDetail GetEventDetails(Guid id);
    }
}
