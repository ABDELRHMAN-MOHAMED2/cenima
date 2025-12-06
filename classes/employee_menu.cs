using System;
using System.Linq;
using System.Collections.Generic;

namespace CinemaBookingLibrary
{
    public class EmployeeMenu
    {
        public void Show()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════╗");
            Console.WriteLine("║        Employee Menu               ║");
            Console.WriteLine("╚════════════════════════════════════╝");

            Console.Write("\nEnter Employee ID: ");
            int empId = int.Parse(Console.ReadLine());

            Employee emp = Database.Instance.Employees.Find(e => e.Id == empId);

            if (emp == null)
            {
                Console.WriteLine("\n✗ Employee not found!");
                Console.ReadKey();
                return;
            }

            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine($"Welcome, {emp.GetName()}!");
                Console.WriteLine($"Job Title: {emp.JobTitle}\n");
                Console.WriteLine("1. View All Customers");
                Console.WriteLine("2. View All Bookings");
                Console.WriteLine("3. Add New Film");
                Console.WriteLine("4. Remove Film");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("\nEnter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewAllCustomers();
                        break;
                    case "2":
                        ViewAllBookings();
                        break;
                    case "3":
                        AddFilm();
                        break;
                    case "4":
                        RemoveFilm();
                        break;
                    case "5":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice!");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void ViewAllCustomers()
        {
            Console.Clear();
            Console.WriteLine("═══ All Customers ═══\n");

            if (Database.Instance.Customers.Count > 0)
            {
                foreach (var customer in Database.Instance.Customers)
                {
                    customer.DisplayInfo();
                    Console.WriteLine("─────────────────────────────");
                }
            }
            else
            {
                Console.WriteLine("No customers registered yet!");
            }

            Console.ReadKey();
        }

        private void ViewAllBookings()
        {
            Console.Clear();
            Console.WriteLine("═══ All Bookings ═══\n");

            var bookedTickets = Database.Instance.Tickets.FindAll(t => t.IsBooked());

            if (bookedTickets.Count > 0)
            {
                foreach (var ticket in bookedTickets)
                {
                    Film film = Database.Instance.Films.Find(f => f.Id == ticket.FilmId);
                    Console.WriteLine($"Ticket #{ticket.Id} - User #{ticket.UserId}");
                    Console.WriteLine($"Film: {film.Name}");
                    Console.WriteLine($"Seat: {ticket.TicketType} #{ticket.SeatId}");
                    Console.WriteLine($"Price: {ticket.Price} EGP");
                    Console.WriteLine("─────────────────────────────");
                }
            }
            else
            {
                Console.WriteLine("No bookings yet!");
            }

            Console.ReadKey();
        }

        private void AddFilm()
        {
            Console.Clear();
            Console.WriteLine("═══ Add New Film ═══\n");

            Console.Write("Enter Film ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Film Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Duration (minutes): ");
            int duration = int.Parse(Console.ReadLine());

            Console.WriteLine("\nAvailable Halls:");
            foreach (var hall in Database.Instance.Halls)
            {
                Console.WriteLine($"{hall.Id}. {hall.Name}");
            }

            Console.Write("\nSelect Hall ID: ");
            int hallId = int.Parse(Console.ReadLine());

            Film newFilm = new Film(id, name, duration, hallId);
            Database.Instance.Films.Add(newFilm);

            Console.WriteLine("\n✓ Film added successfully!");
            Console.ReadKey();
        }

        private void RemoveFilm()
        {
            Console.Clear();
            Console.WriteLine("═══ Remove Film ═══\n");

            Console.WriteLine("Available Films:");
            foreach (var film in Database.Instance.Films)
            {
                Console.WriteLine($"{film.Id}. {film.Name}");
            }

            Console.Write("\nEnter Film ID to remove: ");
            int filmId = int.Parse(Console.ReadLine());

            Film filmToRemove = Database.Instance.Films.Find(f => f.Id == filmId);

            if (filmToRemove != null)
            {
                filmToRemove.RemoveFilm();
                Database.Instance.Films.Remove(filmToRemove);
                Console.WriteLine("\n✓ Film removed successfully!");
            }
            else
            {
                Console.WriteLine("\n✗ Film not found!");
            }

            Console.ReadKey();
        }


    }
}
