using Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Calendar
{
    public class CalendarTests
    {
        [Fact]
        public async Task GetEventsByMonth_WrongMonth_ReturnsFailure()
        {
            // Arrange
            var service = new CalendarService(null,null);

            // Act
            var result = await service.GetEventsByMonth("janray","0");

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Code.Should().Be("NoMonth");
        }
    }
}
