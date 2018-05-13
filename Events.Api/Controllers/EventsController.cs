using Events.Api.Models;
using Events.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Events.Api.Controllers
{
    public class EventsController : Controller
    {
        #region Variables
        private IEventService _eventService;
        #endregion

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [Route("api/events")]
        [HttpGet]
        public IActionResult  GetEvents()
        {
            return Ok(_eventService.GetEvents());
        }

        [Route("api/events/types")]
        [HttpGet]
        public IActionResult GetEventTypes()
        {
            return Ok(_eventService.GetEventTypes());
        }

        [Route("api/events/customer/{id}")]
        [HttpGet]
        public IActionResult GetEventsForCustomer(Guid id)
        {
            return Ok(_eventService.GetEventsForCustomer(id));
        }

        [Route("api/events/searchByTypes")]
        [HttpGet]
        public IActionResult GetEventsForCustomer(Guid id, string type, bool isAllSelected)
        {
            return Ok (_eventService.GetEventsForCustomerByType(id, type, isAllSelected));
        }

        [Route("api/events/searchByDates")]
        [HttpGet]
        public IActionResult GetEventsForCustomerWithDateRange(Guid id, DateTime startDate, DateTime endDate, bool isAllSelected)
        {
            return Ok(_eventService.GetEventsForCustomerByDate(id, startDate, endDate, isAllSelected));
        }

        [Route("api/events/eventdetails/{id}")]
        [HttpGet]
        public IActionResult GetEventDetailsForEvent(Guid id)
        {
            return Ok(_eventService.GetEventDetails(id));
        }

        [Route("api/events/customers")]
        [HttpGet]
        public IActionResult GetCustomers()
        {
            return Ok(_eventService.GetCustomers());
        }
    }
}
