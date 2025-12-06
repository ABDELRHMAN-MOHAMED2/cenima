using System;

namespace CinemaBookingLibrary
{
    
    public class RegularSeat : Seat
    {
        private decimal price;

        public override decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public RegularSeat(int id, int seatId) : base(id, seatId, "Regular")
        {
            price = 50.0m;
        }
    }
}
