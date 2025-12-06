using System;

namespace CinemaBookingLibrary
{
    /// <summary>
    /// Interface for bookable items
    /// Defines contract for booking functionality
    /// </summary>
    public interface IBookable
    {
        bool IsBooked();
        void Book(int userId);
        void CancelBooking();
    }
}
