using System;

namespace CinemaBookingLibrary
{
    /// <summary>
    /// Abstract Seat class
    /// Demonstrates: Abstraction, Abstract Properties, Interface Implementation
    /// </summary>
    public abstract class Seat : IBookable
    {
        public int Id { get; set; }
        public int SeatId { get; set; }
        public bool Booked { get; set; }
        public string SeatType { get; set; }
        public int FilmId { get; set; }
        public int BookerUserId { get; set; }

        // Abstract property - must be implemented by derived classes
        public abstract decimal Price { get; set; }

        // Constructor
        protected Seat(int id, int seatId, string seatType)
        {
            Id = id;
            SeatId = seatId;
            SeatType = seatType;
            Booked = false;
        }

        // Interface implementation
        public bool IsBooked() => Booked;

        // Virtual method - can be overridden
        public virtual void Book(int userId)
        {
            if (!Booked)
            {
                Booked = true;
                BookerUserId = userId;
                Console.WriteLine($"Seat {SeatId} ({SeatType}) booked successfully");
            }
        }

        public void CancelBooking()
        {
            Booked = false;
            BookerUserId = 0;
            Console.WriteLine($"Booking cancelled for seat {SeatId}");
        }
    }
}
