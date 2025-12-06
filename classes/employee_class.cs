using System;

namespace CinemaBookingLibrary
{
    /// <summary>
    /// Employee class
    /// Demonstrates: Inheritance, Method Overloading
    /// </summary>
    public class Employee : Person, IDisplayable
    {
        // Properties
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }

        // Constructor
        public Employee(int id, string name, string jobTitle, string department, decimal salary)
            : base(id, name, "", "", "")
        {
            JobTitle = jobTitle;
            Department = department;
            Salary = salary;
        }

        // Override abstract method
        public override void DisplayRole()
        {
            Console.WriteLine($"Role: Employee - {JobTitle} in {Department}");
        }

        // Method Overloading - same name, different parameters
        

        public void DisplayData(int userId)
        {
            Console.WriteLine($"Displaying data for user #{userId}");
        }
    }
}
