using Api.Services;
using FluentAssertions;

namespace UnitTests.Calendar
{
    public class CalendarTests
    {
        [Fact]
        public async Task GetEventsByMonth_WrongMonth_ReturnsFailure()
        {
            // Arrange
            var service = new CalendarService(null!);

            // Act
            var result = await service.GetEventsByMonth("janray");

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Code.Should().Be("NoMonth");
        }
    }
}