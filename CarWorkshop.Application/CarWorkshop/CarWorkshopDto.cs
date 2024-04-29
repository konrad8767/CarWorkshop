using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;

namespace CarWorkshop.Application.CarWorkshop
{
    public class CarWorkshopDto
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string? About { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }

        public string? EncodedName { get; set; }
        public bool IsEditable {  get; set; }

        public void Update(CarWorkshopDto other)
        {
            Name = other.Name;
            Description = other.Description;
            About = other.About;
            PhoneNumber = other.PhoneNumber;
            Street = other.Street;
            City = other.City;
            PostalCode = other.PostalCode;
        }
    }
}
