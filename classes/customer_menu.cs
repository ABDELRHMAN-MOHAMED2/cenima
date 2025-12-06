using System;
using System.Linq;
using System.Collections.Generic;

namespace CinemaBookingLibrary
{
    public  class CustomerMenu
    {
        public void Show()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════╗");
                Console.WriteLine("║           Customer Menu            ║");
                Console.WriteLine("╚════════════════════════════════════╝");
                Console.WriteLine("\n1. Register New Customer");
                Console.WriteLine("2. Login Customer");
                Console.WriteLine("3. View Available Films");
                Console.WriteLine("4. Book Ticket");
                Console.WriteLine("5. View My Bookings");
                Console.WriteLine("6. Cancel Booking");
                Console.WriteLine("7. Back to Main Menu");
                Console.Write("\nEnter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        RegisterCustomer();
                        break;
                    case "2":
                        LoginCustomer();
                        break;
                    case "3":
                        ViewFilms();
                        break;
                    case "4":
                        BookTicket();
                        break;
                    case "5":
                        ViewBookings();
                        break;
                    case "6":
                        CancelBooking();
                        break;
                    case "7":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice!");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void RegisterCustomer()
        {
            Console.Clear();
            Console.WriteLine("═══ Register New Customer ═══\n");

            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Phone: ");
            string phone = Console.ReadLine();

            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            Customer newCustomer = new Customer(id, name, phone, email, password);
            Database.Instance.Customers.Add(newCustomer);

            Console.WriteLine("\n✓ Customer registered successfully!");
            
            Console.ReadKey();
        }

        private void LoginCustomer()
        {
            Console.Clear();
            Console.WriteLine("═══ Customer Login ═══\n");

            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());

            Customer customer = Database.Instance.Customers.Find(c => c.Id == id);

            if (customer != null)
            {
                Console.Write("Enter Password: ");
                string password = Console.ReadLine();

                if (customer.GetPassword() == password)
                {
                    Console.WriteLine("\n✓ Login successful!");
                    customer.DisplayInfo();
                    customer.DisplayRole();
                }
                else
                {
                    Console.WriteLine("\n✗ Incorrect password!");
                }
            }
            else
            {
                Console.WriteLine("\n✗ Customer not found!");
            }

            Console.ReadKey();
        }

        private void ViewFilms()
        {
            Console.Clear();
            Console.WriteLine("═══ Available Films ═══\n");

            foreach (var film in Database.Instance.Films)
            {
                film.DisplayInfo();
                
                Console.WriteLine("─────────────────────────────");
            }

            Console.ReadKey();
        }

        private void BookTicket()
        {
            Console.Clear();
            Console.WriteLine("═══ Book Ticket ═══\n");

            Console.Write("Enter Customer ID: ");
            int custId = int.Parse(Console.ReadLine());

            Customer customer = Database.Instance.Customers.Find(c => c.Id == custId);

            if (customer == null)
            {
                Console.WriteLine("\n✗ Customer not found! Please register first.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nAvailable Films:");
            for (int i = 0; i < Database.Instance.Films.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Database.Instance.Films[i].Name} - {Database.Instance.Films[i].Duration} min");
            }

            Console.Write("\nSelect Film (1-" + Database.Instance.Films.Count + "): ");
            int filmChoice = int.Parse(Console.ReadLine()) - 1;

            if (filmChoice < 0 || filmChoice >= Database.Instance.Films.Count)
            {
                Console.WriteLine("\n✗ Invalid film selection!");
                Console.ReadKey();
                return;
            }

            Film selectedFilm = Database.Instance.Films[filmChoice];

            Console.WriteLine("\n═══ Available Seats ═══");
            Console.WriteLine("1. Regular Seat (50 EGP)");
            Console.WriteLine("2. VIP Seat (100 EGP)");
            Console.WriteLine("3. Premium Seat (150 EGP)");
            Console.Write("\nSelect Seat Type: ");
            int seatType = int.Parse(Console.ReadLine());

            Seat selectedSeat = null;

            // Find available seat of selected type
            if (seatType == 1)
                selectedSeat = Database.Instance.Seats.Find(s => s is RegularSeat && !s.IsBooked());
            else if (seatType == 2)
                selectedSeat = Database.Instance.Seats.Find(s => s is VIPSeat && !s.IsBooked());
            else if (seatType == 3)
                selectedSeat = Database.Instance.Seats.Find(s => s is PremiumSeat && !s.IsBooked());

            if (selectedSeat != null)
            {
                selectedSeat.Book(customer.Id);

                Ticket ticket = new Ticket(Database.Instance.Tickets.Count + 1, selectedSeat.SeatType, 
                                          selectedSeat.Price, selectedSeat.SeatId);
                ticket.SetFilmId(selectedFilm.Id);
                ticket.Book(customer.Id);
                Database.Instance.Tickets.Add(ticket);

                customer.BuyTicket(ticket);

                Console.WriteLine($"\n✓ Ticket booked successfully!");
                Console.WriteLine($"Ticket ID: {ticket.Id}");
                Console.WriteLine($"Film: {selectedFilm.Name}");
                Console.WriteLine($"Seat: {selectedSeat.SeatType} - #{selectedSeat.SeatId}");
                Console.WriteLine($"Price: {selectedSeat.Price} EGP");
            }
            else
            {
                Console.WriteLine("\n✗ No available seats of this type!");
            }

            Console.ReadKey();
        }

        private void ViewBookings()
        {
            Console.Clear();
            Console.WriteLine("═══ View Bookings ═══\n");

            Console.Write("Enter Customer ID: ");
            int custId = int.Parse(Console.ReadLine());

            var customerTickets = Database.Instance.Tickets.FindAll(t => t.UserId == custId && t.IsBooked());

            if (customerTickets.Count > 0)
            {
                Console.WriteLine($"\nBookings for Customer #{custId}:");
                Console.WriteLine("─────────────────────────────");

                foreach (var ticket in customerTickets)
                {
                    Film film = Database.Instance.Films.Find(f => f.Id == ticket.FilmId);
                    Console.WriteLine($"Ticket #{ticket.Id}");
                    Console.WriteLine($"Film: {film.Name}");
                    Console.WriteLine($"Seat: {ticket.TicketType} - #{ticket.SeatId}");
                    Console.WriteLine($"Price: {ticket.Price} EGP");
                    Console.WriteLine("─────────────────────────────");
                }
            }
            else
            {
                Console.WriteLine("\n✗ No bookings found!");
            }

            Console.ReadKey();
        }

        private void CancelBooking()
        {
            Console.Clear();
            Console.WriteLine("═══ Cancel Booking ═══\n");

            Console.Write("Enter Ticket ID: ");
            int ticketId = int.Parse(Console.ReadLine());

            Ticket ticket = Database.Instance.Tickets.Find(t => t.Id == ticketId);

            if (ticket != null && ticket.IsBooked())
            {
                ticket.CancelBooking();
                Seat seat = Database.Instance.Seats.Find(s => s.SeatId == ticket.SeatId);
                if (seat != null)
                {
                    seat.CancelBooking();
                }

                Console.WriteLine("\n✓ Booking cancelled successfully!");
            }
            else
            {
                Console.WriteLine("\n✗ Ticket not found or already cancelled!");
            }

            Console.ReadKey();
        }
    }
}
