using System;

namespace CinemaBookingLibrary
{
    /// <summary>
    /// VIP Seat - Concrete implementation
    /// Demonstrates: Inheritance from Abstract Class, Property Implementation
    /// </summary>
    public class VIPSeat : Seat
    {
        private decimal price;

        public override decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public VIPSeat(int id, int seatId) : base(id, seatId, "VIP")
        {
            price = 100.0m;
        }
    }
}
