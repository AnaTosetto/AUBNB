using FluentValidation;
using FluentValidation.Results;

namespace AUBNB.Application.Features.Users.Commands
{
    public class UserLoginCommand
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        public class Validator : AbstractValidator<UserLoginCommand>
        {
            public Validator()
            {
                RuleFor(x => x.Email).NotEmpty().MaximumLength(100);
                RuleFor(x => x.Password).NotEmpty();
            }
        }
    }
}
