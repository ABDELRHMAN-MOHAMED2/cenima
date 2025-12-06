using System;

namespace CinemaBookingLibrary
{
    /// <summary>
    /// Premium Seat - Concrete implementation
    /// Demonstrates: Inheritance from Abstract Class, Property Implementation
    /// </summary>
    public class PremiumSeat : Seat
    {
        private decimal price;

        public override decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public PremiumSeat(int id, int seatId) : base(id, seatId, "Premium")
        {
            price = 150.0m;
        }
    }
}
