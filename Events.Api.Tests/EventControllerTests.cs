using Events.Api.Controllers;
using Events.Api.Models;
using Events.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Events.Api.Tests
{
    public class EventControllerTests
    {
        [Fact]
        public void GetAllEvents()
        {
            var controller = new EventsController(new EventService());

            var result = controller.GetEvents();

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var events = okResult.Value.Should().BeAssignableTo<IEnumerable<Event>>().Subject;

            events.Count().Should().Be(4);
        }

        /// <summary>
        /// using Moq
        /// </summary>
        [Fact]
        public void GetAllCustomers()
        {
            var eventServiceMock = new Mock<IEventService>();
            eventServiceMock.Setup(x => x.GetCustomers()).Returns(() => new List<Customer>
              {
                    new Customer { Id = Guid.Parse("19A5EB62-F189-4C97-A64A-ED4EFB180DB8"), Name = "Customer1" },
                    new Customer { Id = Guid.Parse("19A5EB63-F189-4C97-A64A-ED4EFB180DB9"), Name = "Customer2" },
              });
            var controller = new EventsController(eventServiceMock.Object);

            var result = controller.GetCustomers();

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var customers = okResult.Value.Should().BeAssignableTo<IEnumerable<Customer>>().Subject;

            customers.Count().Should().Be(2);
        }
    }
}
