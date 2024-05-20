using Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Models.Calendar.CalendarModels;

namespace Infrastructure.Data
{
    public static class addtestData
    {
        public static void AddTestCalendarData(this ModelBuilder modelBuilder)
        {

            Guid ManagerGuid = Guid.NewGuid();

            Event sampleEvent = new Event
            {
                EventId = 1 ,
                EventPublicId = ManagerGuid.ToString(),
                Name = "Przykładowe wydarzenie",
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(2),
                Month = "May",
                State = "Created",
                Type = "Custom",
                Description = "To jest opis przykładowego wydarzenia",
                Invited= "8e445865-a24d-4543-a6c6-9443d048cdb9,id2",
                owner = "John Doe" // Przykładowy właściciel
            };
            modelBuilder.Entity<Event>().HasData(sampleEvent);
        }
    }
}
