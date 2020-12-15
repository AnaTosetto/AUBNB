using AUBNB.Domain.Features.Users;
using System.ComponentModel.DataAnnotations;

namespace AUBNB.Domain.Features.Hostings
{
    public class Hosting
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Note { get; set; }
        public bool Availability { get; set; }
        public string HasDog { get; set; }
        public string PlaceDescription { get; set; }
        public string PatioSize { get; set; }
        public string HousingType { get; set; }
        public string AnimalSize { get; set; }

        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string AdditionalInfo { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}