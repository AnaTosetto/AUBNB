using AUBNB.Domain.Features.Users;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AUBNB.Application.Features.Users.Commands
{
    public class UserCreateCommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
        public string Password { get; set; }

        public ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        public class Validator : AbstractValidator<UserCreateCommand>
        {
            public Validator()
            {
                RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
                RuleFor(x => x.Email).NotEmpty().MaximumLength(100);
                RuleFor(x => x.TelephoneNumber).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
            }
        }
    }
}
