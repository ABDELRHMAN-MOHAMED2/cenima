using System;
using CinemaBookingLibrary;

namespace CinemaBookingLibrary
{
    public class MainMenu
    {
        private CustomerMenu customerMenu;
        private EmployeeMenu employeeMenu;
        private SystemStatisticsMenu systemStatisticsMenu;

        public MainMenu()
        {
            customerMenu = new CustomerMenu();
            employeeMenu = new EmployeeMenu();
            systemStatisticsMenu = new SystemStatisticsMenu();
        }

        public void Show()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════════╗");
                Console.WriteLine("║   Cinema Booking System - OOP Project  ║");
                Console.WriteLine("╚════════════════════════════════════════╝");
                Console.WriteLine("\n1. Customer Menu");
                Console.WriteLine("2. Employee Menu");
                Console.WriteLine("3. Display System Statistics");
                Console.WriteLine("4. Exit");
                Console.Write("\nEnter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        customerMenu.Show();
                        break;
                    case "2":
                        employeeMenu.Show();
                        break;
                    case "3":
                        systemStatisticsMenu.Show();
                        break;
                    case "4":
                        exit = true;
                        Console.WriteLine("\nThank you for using Cinema Booking System!");
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice! Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
