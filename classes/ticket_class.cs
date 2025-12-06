using System;

namespace CinemaBookingLibrary
{
    /// <summary>
    /// Ticket class
    /// Implements: IBookable interface
    /// Demonstrates: Interface Implementation, Encapsulation
    /// </summary>
    public class Ticket : IBookable
    {
        public int Id { get; set; }
        public string TicketType { get; set; }
        public decimal Price { get; set; }
        public int SeatId { get; set; }
        public int UserId { get; set; }
        public int FilmId { get; set; }
        public int SeatNum { get; set; }
        public bool Booked { get; set; }

        public Ticket(int id, string type, decimal price, int seatId)
        {
            Id = id;
            TicketType = type;
            Price = price;
            SeatId = seatId;
            Booked = false;
        }

        public void SetSeatId(int seatId)
        {
            SeatId = seatId;
        }

        public void SetFilmId(int filmId)
        {
            FilmId = filmId;
        }

        public void SetUserId(int userId)
        {
            UserId = userId;
        }

        public bool IsBooked() => Booked;

        public void Book(int userId)
        {
            if (!Booked)
            {
                Booked = true;
                UserId = userId;
                Console.WriteLine($"Ticket #{Id} booked for user #{userId}");
            }
        }

        public void CancelBooking()
        {
            Booked = false;
            UserId = 0;
            Console.WriteLine($"Ticket #{Id} booking cancelled");
        }
    }
}
