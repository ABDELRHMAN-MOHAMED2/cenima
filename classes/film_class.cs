using System;

namespace CinemaBookingLibrary
{
    /// <summary>
    /// Film class
    /// Demonstrates: Interface Implementation, Encapsulation
    /// </summary>
    public class Film : IDisplayable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int HallId { get; set; }

        public Film(int id, string name, int duration, int hallId)
        {
            Id = id;
            Name = name;
            Duration = duration;
            HallId = hallId;
        }

        public void AddFilm(string name)
        {
            Name = name;
            Console.WriteLine($"Film '{name}' added successfully");
        }

       
        public void RemoveFilm()
        {
            Console.WriteLine($"Film '{Name}' removed");
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Film: {Name}, Duration: {Duration} min, Hall: {HallId}");
        }
    }
}
