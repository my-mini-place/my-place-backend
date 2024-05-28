using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class CalendarModels
    {
        //public class Month
        //{
        //    [Key]
        //    public int MonthId { get; set; }

        // public int MonthNumber { get; set; } // Numer miesiąca (np. styczeń - 1, luty - 2, etc.)

        //    public ICollection<Day> Days { get; set; }
        //}

        //public class Day
        //{
        //    [Key]
        //    public int DayId { get; set; }

        // public DateTime Date { get; set; } // Data dnia

        // // Klucz obcy do miesiąca public int MonthId { get; set; } public Month Month { get; set; }

        //    public ICollection<Event> Events { get; set; }
        //}

        public class Event
        {
            [Key]
            public int EventId { get; set; }

            public string EventPublicId { get; set; } = null!;
            public string Name { get; set; } = null!;
            public string Month { get; set; } = null!;

            public DateTime StartTime { get; set; } // Czas rozpoczęcia wydarzenia

            public DateTime EndTime { get; set; } // Czas zakończenia wydarzenia

            public string State { get; set; } = null!;

            public string Type { get; set; } = null!;
            public string Description { get; set; } = null!;

            //public List<string>? Invited { get; set; }

            public string? owner { get; set; }
        }

        public class ReservationManager
        {
            private List<(DateTime Start, DateTime End)> reservations = new List<(DateTime, DateTime)>();

            public bool IsAvailable(DateTime start, DateTime end)
            {
                foreach (var reservation in reservations)
                {
                    if (start < reservation.End && end > reservation.Start)
                    {
                        return false;
                    }
                }
                return true;
            }

            public void Reserve(DateTime start, DateTime end)
            {
                reservations.Add((start, end));
            }

            public void Cancel(DateTime start, DateTime end)
            {
                var reservationToRemove = reservations.FirstOrDefault(r => r.Start == start && r.End == end);
                if (reservationToRemove != default)
                {
                    reservations.Remove(reservationToRemove);
                }
            }
        }
    }
}