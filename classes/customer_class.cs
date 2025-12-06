using System;

namespace CinemaBookingLibrary
{
    /// <summary>
    /// Customer class - Sealed class (cannot be inherited)
    /// Demonstrates: Inheritance, Polymorphism, Method Overriding, Sealed Class
    /// </summary>
    public sealed class Customer : Person, IDisplayable
    {
        // Instance Members
        public int FilmId { get; set; }
        public int TicketId { get; set; }
        public string History { get; set; }
        public int HallId { get; set; }
        public int SeatId { get; set; }

        // Default Constructor calls base
        public Customer() : base()
        {
            History = "";
        }

        // Parameterized Constructor
        public Customer(int id, string name, string phone, string email, string password)
            : base(id, name, phone, email, password)
        {
            History = "";
        }

        // Method Overriding - Override keyword
        public override void DisplayRole()
        {
            Console.WriteLine($"Role: Customer - {GetName()}");
        }

        // Override base class virtual method
        public override void DisplayInfo()
        {
            base.DisplayInfo(); // Super/Base keyword usage
            Console.WriteLine($"Ticket ID: {TicketId}, Hall ID: {HallId}, Seat ID: {SeatId}");
        }

        // Method specific to Customer
        public void BuyTicket(Ticket ticket)
        {
            TicketId = ticket.Id;
            FilmId = ticket.FilmId;
            SeatId = ticket.SeatId;
            History += $"Bought ticket {TicketId} on {DateTime.Now}\n";
            Console.WriteLine($"Customer {GetName()} bought ticket #{TicketId}");
        }
    }
}
