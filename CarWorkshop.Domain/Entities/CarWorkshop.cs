using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Domain.Entities
{
    public class CarWorkshop
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public CarWorkshopContactDetails ContactDetails { get; set; } = default!;
        public string? About { get; set; }
        public string? CreatedById { get; set; }
        public IdentityUser? CreatedBy { get; set; }

        public string EncodedName { get; private set; } = default!;

        public List<CarWorkshopService> Services { get; set; } = new();

        public void EncodeName() => EncodedName = Name.ToLower().Replace(" ", "-");


        public void Update(CarWorkshop other)
        {
            Id = other.Id;
            Name = other.Name;
            Description = other.Description;
            CreatedAt = other.CreatedAt;
            ContactDetails = other.ContactDetails;
            About = other.About;
            EncodedName = other.EncodedName;
        }
    }
}
