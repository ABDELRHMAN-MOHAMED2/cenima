using System;
using System.Linq;
using System.Collections.Generic;

namespace CinemaBookingLibrary
{
    public class SystemStatisticsMenu
    {
        public void Show()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║       System Statistics                ║");
            Console.WriteLine("╚════════════════════════════════════════╝\n");

            Console.WriteLine($"Total Persons Created: {Person.GetPersonCount()}");
            Console.WriteLine($"Total Customers: {Database.Instance.Customers.Count}");
            Console.WriteLine($"Total Employees: {Database.Instance.Employees.Count}");
            Console.WriteLine($"Total Films: {Database.Instance.Films.Count}");
            Console.WriteLine($"Total Halls: {Database.Instance.Halls.Count}");
            Console.WriteLine($"Total Seats: {Database.Instance.Seats.Count}");
            Console.WriteLine($"Booked Seats: {Database.Instance.Seats.Count(s => s.IsBooked())}");
            Console.WriteLine($"Available Seats: {Database.Instance.Seats.Count(s => !s.IsBooked())}");
            Console.WriteLine($"Total Tickets Sold: {Database.Instance.Tickets.Count(t => t.IsBooked())}");
            Console.WriteLine($"Total Revenue: {Database.Instance.Tickets.Where(t => t.IsBooked()).Sum(t => t.Price)} EGP");

            Console.ReadKey();
        }
    }
}
