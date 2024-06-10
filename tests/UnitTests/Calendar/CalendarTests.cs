using Api.Services;
using Domain;
using Domain.Models.Identity;
using Domain.IRepositories;
using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Infrastructure.Data;
using static Domain.Calendar;
using static Domain.Models.Calendar.CalendarModels;
using Api.Interfaces;
using System.Linq.Expressions;
using System.Xml;
using NSubstitute;

namespace UnitTests.Calendar
{
   
    public class CalendarTests
    {
        private readonly Mock<ICalendarRepository> _mockCalendarRepository;
        private readonly Mock<UserManager<ApplicationUser>> _mockUserManager;
        private readonly Mock<IIdentityRepository> _mockIdentityRepository;
        private readonly CalendarService _calendarService;

        public CalendarTests()
        {
            _mockCalendarRepository = new Mock<ICalendarRepository>();
            _mockUserManager = new Mock<UserManager<ApplicationUser>>(
                new Mock<IUserStore<ApplicationUser>>().Object,
                null, null, null, null, null, null, null, null);
            _mockIdentityRepository = new Mock<IIdentityRepository>();

            _calendarService = new CalendarService(
                _mockCalendarRepository.Object,
                _mockUserManager.Object,
                _mockIdentityRepository.Object);
        }

        [Fact]
        public async Task GetEventsByMonth_WrongMonth_ReturnsFailure()
        { 
            var result = await _calendarService.GetEventsByMonth("janray", "0");
            result.IsSuccess.Should().BeFalse();
            result.Error.Code.Should().Be("NoMonth");
        }

        [Fact(Skip = "Cant test until CalendarMapper has interface")]
        public async Task GetEventsByMonth_ValidMonth_ReturnsEvents()
        {
            string month = "January";
            string userId = "testUser";
            var events = new List<Event>
            {
                new Event { Month = "January", owner = userId, EventPublicId = "event1" }
            };
            _mockCalendarRepository
                .Setup(repo => repo.GetAll(It.IsAny<Expression<Func<Event, bool>>>(), It.IsAny<string>()))
                .ReturnsAsync(events);
            var result = await _calendarService.GetEventsByMonth(month, userId);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task GetEventsByMonth_InvalidMonth_ReturnsFailure()
        {
            string month = "InvalidMonth";
            string userId = "testUser";
            var result = await _calendarService.GetEventsByMonth(month, userId);
            result.IsSuccess.Should().BeFalse();
            result.Error.Code.Should().Be("NoMonth");
        }

        [Fact]
        public async Task GetUsers_ValidName_ReturnsUsers()
        {
            string name = "test";
            string role = "";
            var users = new List<ApplicationUser>
            {
                new ApplicationUser { Email = "testuser@example.com", Id = "1" }
            };
            _mockUserManager.Setup(um => um.Users).Returns(users.AsQueryable());
            var result = await _calendarService.GetUsers(name, role);
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().HaveCount(1);
            result.Value[0].email.Should().Be("testuser@example.com");
        }

        [Fact]
        public async Task GetUsers_InValidRole_ReturnsFailure()
        {
            string name = "test";
            string role = "invalidrole!!!!!";
            var users = new List<ApplicationUser>
            {
                new ApplicationUser { Email = "testuser@example.com", Id = "1" }
            };
            _mockUserManager.Setup(um => um.Users).Returns(users.AsQueryable());
            var result = await _calendarService.GetUsers(name, role);
            result.IsSuccess.Should().BeFalse();
            result.Error.Code.Should().Be("NoSuchRole");

        }
        [Fact]
        public async Task AddUserEvent_ValidEvent_ReturnsSuccess()
        {
            var eventDto = new CalendarEventDto
            {
                Type = "Meeting",
                Description = "Test Event Description",
                From = DateTime.Now.AddHours(1),
                To = DateTime.Now.AddHours(2),
                Invited = new List<string> { "user1", "user2" },
                State = "Pending"
            };
            string ownerId = "owner1";

            _mockCalendarRepository
                .Setup(repo => repo.Add(It.IsAny<Event>()))
                .Returns(Task.CompletedTask);

            var result = await _calendarService.AddUserEvent(eventDto, ownerId);
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().NotBeNull();
        }




        [Fact]
        public async Task AcceptOrRejectEvent_ValidEvent_ReturnsSuccess()
        {
            string eventId = "event1";
            string actionDto = "Accept";
            string ownerId = "owner1";
            var eventObj = new Event { EventPublicId = eventId, Invited = "" + ownerId };

            _mockCalendarRepository
                .Setup(repo => repo.Get(It.IsAny<Expression<Func<Event, bool>>>(), It.IsAny<string>(), It.IsAny<bool>()))
                .ReturnsAsync(eventObj);

            _mockCalendarRepository
                .Setup(repo => repo.Update(It.IsAny<Event>()));

            var result = await _calendarService.AcceptOrRejectEvent(eventId, actionDto, ownerId);
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be("Event Accepted!!");
        }
    }
    
}
