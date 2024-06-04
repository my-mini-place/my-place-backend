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
            // Arrange
            var service = new CalendarService(null, null, null);

            // Act
            var result = await service.GetEventsByMonth("janray", "0");

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Code.Should().Be("NoMonth");
        }

        //[Fact]
        //public async Task GetEventsByMonth_ValidMonth_ReturnsEvents()
        //{
        //    // Arrange
        //    string month = "January";
        //    string userId = "testUser";
        //    var events = new List<Event>
        //    {
        //        new Event { Month = "January", Owner = userId, EventPublicId = "event1" }
        //    };
        //    _mockCalendarRepository
        //        .Setup(repo => repo.GetAll(It.IsAny<Func<Event, bool>>()))
        //        .ReturnsAsync(events);

        //    // Act
        //    var result = await _calendarService.GetEventsByMonth(month, userId);

        //    // Assert
        //    result.IsSuccess.Should().BeTrue();
        //    result.Value.Should().NotBeNull();
        //}

        [Fact]
        public async Task GetEventsByMonth_InvalidMonth_ReturnsFailure()
        {
            // Arrange
            string month = "InvalidMonth";
            string userId = "testUser";

            // Act
            var result = await _calendarService.GetEventsByMonth(month, userId);

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Code.Should().Be("NoMonth");
        }

        [Fact]
        public async Task GetUsers_ValidName_ReturnsUsers()
        {
            // Arrange
            string name = "test";
            string role = "";
            var users = new List<ApplicationUser>
            {
                new ApplicationUser { Email = "testuser@example.com", Id = "1" }
            };
            _mockUserManager.Setup(um => um.Users).Returns(users.AsQueryable());

            // Act
            var result = await _calendarService.GetUsers(name, role);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().HaveCount(1);
            result.Value[0].email.Should().Be("testuser@example.com");
        }

        [Fact]
        public async Task AddUserEvent_ValidEvent_ReturnsSuccess()
        {
            // Arrange
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

            // Act
            var result = await _calendarService.AddUserEvent(eventDto, ownerId);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().NotBeNull();
        }

        //[Fact]
        //public async Task AcceptOrRejectEvent_ValidEvent_ReturnsSuccess()
        //{
        //    // Arrange
        //    string eventId = "event1";
        //    string actionDto = "Accept";
        //    string ownerId = "owner1";
        //    var eventObj = new Event { EventPublicId = eventId, Invited =""+ ownerId};

        //    _mockCalendarRepository
        //        .Setup(repo => repo.Get(It.IsAny<Func<Event, bool>>()))
        //        .ReturnsAsync(eventObj);

        //    _mockCalendarRepository
        //        .Setup(repo => repo.Update(It.IsAny<Event>()))
        //        .Returns(Task.CompletedTask);

        //    // Act
        //    var result = await _calendarService.AcceptOrRejectEvent(eventId, actionDto, ownerId);

        //    // Assert
        //    result.IsSuccess.Should().BeTrue();
        //    result.Value.Should().Be("Event Accepted!!");
        //}

        //    [Fact]
        //    public async Task AcceptOrRejectEvent_InvalidAction_ReturnsFailure()
        //    {
        //        // Arrange
        //        string eventId = "event1";
        //        string actionDto = "InvalidAction";
        //        string ownerId = "owner1";
        //        var eventObj = new Event { EventPublicId = eventId, Invited = new List<string> { ownerId } };

        //        _mockCalendarRepository
        //            .Setup(repo => repo.Get(It.IsAny<Func<Event, bool>>()))
        //            .ReturnsAsync(eventObj);

        //        // Act
        //        var result = await _calendarService.AcceptOrRejectEvent(eventId, actionDto, ownerId);

        //        // Assert
        //        result.IsSuccess.Should().BeFalse();
        //        result.Error.Code.Should().Be("NoSuchAction");
        //    }
        //}

        //public class FreeTimeManagerTests
        //{
        //    [Fact]
        //    public void GetFreeTimeSlots_NoEvents_ReturnsFullDaySlot()
        //    {
        //        // Arrange
        //        var events = new List<Event>();
        //        DateTime day = new DateTime(2023, 5, 27);

        //        // Act
        //        var result = FreeTimeManager.GetFreeTimeSlots(events, day);

        //        // Assert
        //        result.Should().HaveCount(1);
        //        result[0].Start.Should().Be(day);
        //        result[0].End.Should().Be(day.AddDays(1).AddSeconds(-1));
        //    }

        //    [Fact]
        //    public void GetFreeTimeSlots_WithEvents_ReturnsCorrectSlots()
        //    {
        //        // Arrange
        //        DateTime day = new DateTime(2023, 5, 27);
        //        var events = new List<Event>
        //        {
        //            new Event { StartTime = day.AddHours(9), EndTime = day.AddHours(10) },
        //            new Event { StartTime = day.AddHours(12), EndTime = day.AddHours(13) }
        //        };

        //        // Act
        //        var result = FreeTimeManager.GetFreeTimeSlots(events, day);

        //        // Assert
        //        result.Should().HaveCount(3);
        //        result[0].Start.Should().Be(day);
        //        result[0].End.Should().Be(day.AddHours(9));
        //        result[1].Start.Should().Be(day.AddHours(10));
        //        result[1].End.Should().Be(day.AddHours(12));
        //        result[2].Start.Should().Be(day.AddHours(13));
        //        result[2].End.Should().Be(day.AddDays(1).AddSeconds(-1));
        //    }
    }
    
}
