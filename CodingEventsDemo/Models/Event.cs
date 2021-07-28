using System;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CodingEventsDemo.Models
{
    public class Event
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
        public string Name { get; set; }

        public string Description { get; set; }

        [EmailAddress]
        public string ContactEmail { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        [StringLength(85, MinimumLength = 3, ErrorMessage = "Location must be between 1 and 85 characters")]
        public string Location { get; set; }
        [Required(ErrorMessage = "Number of Attendees is required.")]
        [Range(0, 100000, ErrorMessage = "Number of Attendees can only be between 0 and 100,000")]
        public int NumberOfAttendees { get; set; }

        public int Id { get; }
        static private int nextId = 1;

        public Event(string name, string description, string contactEmail, string location, int numberOfAttendees)
        {
            Name = name;
            Description = description;
            ContactEmail = contactEmail;
            Location = location;
            NumberOfAttendees = numberOfAttendees;
            Id = nextId;
            nextId++;
        }

        public Event()
        {
            Id = nextId;
            nextId++;
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            return obj is Event @event &&
                   Id == @event.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
