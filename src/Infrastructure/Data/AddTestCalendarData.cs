using Microsoft.EntityFrameworkCore;
using static Domain.Models.CalendarModels;

namespace Infrastructure.Data
{
    public static class addtestData
    {
        public static void AddTestCalendarData(this ModelBuilder modelBuilder)
        {
            Guid ManagerGuid = Guid.NewGuid();

            Event sampleEvent = new Event
            {
                EventId = 1,
                EventPublicId = ManagerGuid.ToString(),
                Name = "Przykładowe wydarzenie",
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(2),
                Month = "May",
                State = "Created",
                Type = "Custom",
                Description = "To jest opis przykładowego wydarzenia",
                owner = "John Doe" // Przykładowy właściciel
            };
            modelBuilder.Entity<Event>().HasData(sampleEvent);
        }
    }
}