using System;

namespace CinemaBookingLibrary
{
    /// <summary>
    /// Abstract base class for all persons in the system
    /// Demonstrates: Abstraction, Encapsulation, Static Members, Properties
    /// </summary>
    public abstract class Person
    {
        // Properties with Getter/Setter
        public int Id { get; set; }
        public string Name { get; set; }
        public string IdType { get; set; }
        public string Phone { get; set; }
        protected string Password { get; set; }
        public string Email { get; set; }

        // Static Members
        protected static int personCount = 0;

        // Default Constructor
        protected Person()
        {
            personCount++;
        }

        // Parameterized Constructor
        protected Person(int id, string name, string phone, string email, string password)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Email = email;
            Password = password;
            personCount++;
        }

        // Getter and Setter Methods
        public void SetName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
                Name = name;
        }

        public string GetName() => Name;

        public void SetPhone(string phone)
        {
            if (!string.IsNullOrWhiteSpace(phone))
                Phone = phone;
        }

        public string GetPhone() => Phone;

        public void SetEmail(string email)
        {
            if (!string.IsNullOrWhiteSpace(email) && email.Contains("@"))
                Email = email;
        }

        public string GetEmail() => Email;

        public void SetPassword(string password)
        {
            if (!string.IsNullOrWhiteSpace(password) && password.Length >= 6)
                Password = password;
        }

        public string GetPassword() => Password;

        // Static Method
        public static int GetPersonCount() => personCount;

        // Abstract Method - must be implemented by derived classes
        public abstract void DisplayRole();

        // Virtual Method - can be overridden
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}, Email: {Email}");
        }
    }
}
