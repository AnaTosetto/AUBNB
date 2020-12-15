using FluentValidation;
using FluentValidation.Results;

namespace AUBNB.Application.Features.Users.Commands
{
    public class UserUpdateCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
        public string Password { get; set; }

        public ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        public class Validator : AbstractValidator<UserUpdateCommand>
        {
            public Validator()
            {
                RuleFor(x => x.Id).NotEmpty();
                RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
                RuleFor(x => x.Email).NotEmpty().MaximumLength(100);
                RuleFor(x => x.TelephoneNumber).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
            }
        }
    }
}
