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
