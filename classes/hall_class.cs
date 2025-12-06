using System;

namespace CinemaBookingLibrary
{
    /// <summary>
    /// Hall class
    /// Demonstrates: Encapsulation, Properties, This Keyword
    /// </summary>
    public class Hall
    {
        // Private fields - Encapsulation
        private int id;
        private string name;
        
        // Public Properties
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

       

       

        // Constructor with This keyword
        public Hall(int id, string name)
        {
            this.id = id;
            this.name = name;
            
        }


    }
}
