using FluentValidation;
using FluentValidation.Results;

namespace AUBNB.Application.Features.Hostings.Commands
{
    public class HostingCreateCommand
    {
        public string Description { get; set; }
        public double Price { get; set; }
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

        public ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        public class Validator : AbstractValidator<HostingCreateCommand>
        {
            public Validator()
            {
                
            }
        }
    }
}
