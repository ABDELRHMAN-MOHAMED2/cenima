using System;
using CinemaBookingLibrary;

namespace CinemaBookingApp
{
    class Program
    {
        static void Main(string[] args)
        {
           
            var db = Database.Instance;
             
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }
    }
}
/*
 * ════════════════════════════════════════════════════════════════
 * MAIN PROGRAM - Cinema Booking Application
 * ════════════════════════════════════════════════════════════════
 * 
 * This is the main application that uses CinemaBookingLibrary
 * 
 * STRUCTURE:
 * ─────────────────────────────────────────────────────────────
 * 1. Customer Menu
 *    - Register New Customer
 *    - Login
 *    - View Films
 *    - Book Tickets
 *    - View Bookings
 *    - Cancel Booking
 * 
 * 2. Employee Menu
 *    - View All Customers
 *    - View All Bookings
 *    - Add Films
 *    - Remove Films
 *    - Update Employee Data (Method Overloading Demo)
 * 
 * 3. System Statistics
 *    - Display all system stats
 * ______________________________________________________________
 */