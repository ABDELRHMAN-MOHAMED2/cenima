using System;
using System.Collections.Generic;

namespace CinemaBookingLibrary
{
    public class Database
    {
        private static Database _instance;
        public static Database Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Database();
                return _instance;
            }
        }

        public List<Customer> Customers { get; private set; }
        public List<Employee> Employees { get; private set; }
        public List<Hall> Halls { get; private set; }
        public List<Film> Films { get; private set; }
        public List<Seat> Seats { get; private set; }
        public List<Ticket> Tickets { get; private set; }

        private Database()
        {
            Customers = new List<Customer>();
            Employees = new List<Employee>();
            Halls = new List<Hall>();
            Films = new List<Film>();
            Seats = new List<Seat>();
            Tickets = new List<Ticket>();
            InitializeData();
        }

        private void InitializeData()
        {
            // Create Halls
            Halls.Add(new Hall(1, "Hall 1"));
            Halls.Add(new Hall(2, "Hall 2"));
            Halls.Add(new Hall(3, "Hall 3"));

            // Create Films
            Films.Add(new Film(1, "Avatar 3", 180, 1));
            Films.Add(new Film(2, "Spider-Man", 150, 2));
            Films.Add(new Film(3, "The Batman", 170, 3));

            // Create Seats for each hall
            for (int i = 1; i <= 15; i++)
            {
                if (i <= 5)
                    Seats.Add(new RegularSeat(i, 100 + i));
                else if (i <= 10)
                    Seats.Add(new VIPSeat(i, 200 + i));
                else
                    Seats.Add(new PremiumSeat(i, 300 + i));
            }

            // Create sample employee
            Employees.Add(new Employee(101, "Abdelrhman", "Manager", "Operations", 5000000));
            Employees.Add(new Employee(102, "Moamen", "Manager", "Operations", 5000000));
            Employees.Add(new Employee(103, "Kareem", "Manager", "Operations", 5000000));
        }
    }
}
