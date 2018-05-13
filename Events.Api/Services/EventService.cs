using Events.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Events.Api.Services
{
    public class EventService : IEventService
    {
        public EventService()
        {
            createEventTypes();
            createEvent();
            createCustomerData();
            createEventDetails();
            createCustomerEventData();
        }

        #region properties
        private List<EventType> eventTypes = new List<EventType>();
        private List<Customer> customers = new List<Customer>();
        private List<Event> events = new List<Event>();
        private List<CustomerEvent> customerEvents = new List<CustomerEvent>();
        private List<EventDetail> eventDetail = new List<EventDetail>();
        #endregion

        #region Create Data for Events, Customer, EventDetail and CustomerEvent tables

        public void createEventTypes()
        {
            eventTypes.Add(new EventType { Code = "TRAN", Type = "TransactionEvent" });
            eventTypes.Add(new EventType { Code = "CUST", Type = "CustomEvent" });
        }
        /// <summary>
        /// In real case these will be actual tables
        /// </summary>
        public void createCustomerData()
        {
            customers.Add(new Customer { Id = Guid.Parse("19A5EB62-F189-4C97-A64A-ED4EFB180DB8"), Name = "Customer1" });
            customers.Add(new Customer { Id = Guid.Parse("19A5EB63-F189-4C97-A64A-ED4EFB180DB9"), Name = "Customer2" });
        }

        /// <summary>
        /// In real case these will be actual tables
        /// </summary>
        public void createEvent()
        {
            events.Add(new Event { Id = Guid.Parse("53E7905A-D578-4EBA-96DD-24EEBF4ED4E8"), Type = "TransactionEvent", EventCreateDate = new DateTime(2018, 4, 21), EventEndDate = new DateTime(2018, 4, 26) });
            events.Add(new Event { Id = Guid.Parse("53E7905B-D578-4EBA-96DD-24EEBF4ED4E9"), Type = "TransactionEvent", EventCreateDate = new DateTime(2018, 4, 22), EventEndDate = new DateTime(2018, 4, 27) });
            events.Add(new Event { Id = Guid.Parse("53E7905C-D578-4EBA-96DD-24EEBF4ED4E7"), Type = "CustomEvent", EventCreateDate = new DateTime(2018, 4, 20), EventEndDate = new DateTime(2018, 4, 28) });
            events.Add(new Event { Id = Guid.Parse("53E7905D-D578-4EBA-96DD-24EEBF4ED4E6"), Type = "CustomEvent", EventCreateDate = new DateTime(2018, 4, 22), EventEndDate = new DateTime(2018, 4, 29) });
        }

        /// <summary>
        /// In real cases these will be actual tables
        /// </summary>
        public void createCustomerEventData()
        {
            customerEvents.Add(new CustomerEvent { CustomerId = Guid.Parse("19A5EB62-F189-4C97-A64A-ED4EFB180DB8"), EventId = Guid.Parse("53E7905A-D578-4EBA-96DD-24EEBF4ED4E8") });
            customerEvents.Add(new CustomerEvent { CustomerId = Guid.Parse("19A5EB63-F189-4C97-A64A-ED4EFB180DB9"), EventId = Guid.Parse("53E7905B-D578-4EBA-96DD-24EEBF4ED4E9") });
            customerEvents.Add(new CustomerEvent { CustomerId = Guid.Parse("19A5EB62-F189-4C97-A64A-ED4EFB180DB8"), EventId = Guid.Parse("53E7905C-D578-4EBA-96DD-24EEBF4ED4E7") });
            customerEvents.Add(new CustomerEvent { CustomerId = Guid.Parse("19A5EB63-F189-4C97-A64A-ED4EFB180DB9"), EventId = Guid.Parse("53E7905D-D578-4EBA-96DD-24EEBF4ED4E6") });
        }

        public void createEventDetails()
        {
            //Transaction Events
            eventDetail.Add(new EventDetail { Id = Guid.Parse("830F7D93-D5E0-47BE-9986-EF3068717856"), EventId = Guid.Parse("53E7905A-D578-4EBA-96DD-24EEBF4ED4E8"), Description = "CK event details" });
            eventDetail.Add(new EventDetail { Id = Guid.Parse("830F7D93-D5E1-47BE-9986-EF3068717857"), EventId = Guid.Parse("53E7905B-D578-4EBA-96DD-24EEBF4ED4E9"), Description = "Pumma event details" });

            //Custom Events
            eventDetail.Add(new EventDetail { Id = Guid.Parse("830F7D93-D5E2-47BE-9986-EF3068717858"), EventId = Guid.Parse("53E7905C-D578-4EBA-96DD-24EEBF4ED4E7"), Description = "Nike event details" });
            eventDetail.Add(new EventDetail { Id = Guid.Parse("830F7D93-D5E3-47BE-9986-EF3068717859"), EventId = Guid.Parse("53E7905D-D578-4EBA-96DD-24EEBF4ED4E6"), Description = "Adidas event details" });
        }
        #endregion

        #region Methods
        /// <summary>
        /// This method gets all eventtypes available.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EventType> GetEventTypes()
        {
            return eventTypes.ToList();
        }

        /// <summary>
        /// This methods returns the list of all events
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Event> GetEvents()
        {
            return events;
        }

        /// <summary>
        /// This methods returns the events for the customer.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Event> GetEventsForCustomer(Guid id)
        {
            var eventIds = customerEvents.Where(a => a.CustomerId == id).Select(a => a.EventId);
            List<Event> customerevents =  events.Where(a => eventIds.Contains(a.Id)).ToList() ;
            return customerevents;
        }

        /// <summary>
        /// This methods returns the details of event for an event.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EventDetail GetEventDetails(Guid id)
        {
            EventDetail eventDetails = eventDetail.Where(a => a.EventId == id).FirstOrDefault();
            return eventDetails;
        }

        /// <summary>
        /// This method returns the list of all customers.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Customer> GetCustomers()
        {
            return customers.ToList();
        }

        /// <summary>
        /// This method filters the events based on the type i.e TransactionEvent or CustomEvent.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <param name="isAllSelected"></param>
        /// <returns></returns>
        public IEnumerable<Event> GetEventsForCustomerByType(Guid id, string type, bool isAllSelected)
        {

            var eventIds = !isAllSelected ? customerEvents.Where(a => a.CustomerId == id).Select(a => a.EventId) : customerEvents.Select(a => a.EventId);
            List<Event> customerevents = events.Where(a => eventIds.Contains(a.Id) && a.Type == type).ToList();
            return customerevents;
        }

        /// <summary>
        /// This method returns the events which are in startdate and enddate selected by the user.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="isAllSelected"></param>
        /// <returns></returns>
        public IEnumerable<Event> GetEventsForCustomerByDate(Guid id, DateTime startDate, DateTime endDate, bool isAllSelected)
        {
            var eventIds = !isAllSelected ? customerEvents.Where(a => a.CustomerId == id).Select(a => a.EventId) : customerEvents.Select(a => a.EventId);
            List<Event> customerevents = events.Where(a => eventIds.Contains(a.Id) && a.EventCreateDate.Date >= startDate && a.EventEndDate.Date <= endDate).ToList();
            return customerevents;
        }
        #endregion
    }
}
