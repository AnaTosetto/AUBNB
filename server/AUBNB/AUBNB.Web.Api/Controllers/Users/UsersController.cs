using AUBNB.Application.Features.Users;
using AUBNB.Application.Features.Users.Commands;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using System.Threading.Tasks;
using System;
using AUBNB.Domain.Features.Users;

namespace AUBNB.Web.Api.Controllers.Users
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ObjectResult> PostAsync(UserCreateCommand command)
        {
            ValidationResult resultadoValidacao = command.Validate();

            if (!resultadoValidacao.IsValid)
                throw new Exception("Erro de validação!");

           await _userService.AddAsync(command);

            return StatusCode(201, command); 
        }

        [HttpPut]
        public async Task<ObjectResult> PutAsync(UserUpdateCommand command)
        {
            ValidationResult resultadoValidacao = command.Validate();

            if (!resultadoValidacao.IsValid)
                throw new Exception("Erro de validação!");

            await _userService.UpdateAsync(command);

            return StatusCode(201, command);
        }

        [HttpPost]
        [Route("login")]
        public async Task<User> VerifyLogin(UserLoginCommand command)
        {
            ValidationResult resultadoValidacao = command.Validate();

            if (!resultadoValidacao.IsValid)
                throw new Exception("Erro! Preencha todos os campos!");

            return await _userService.VerifyLoginAsync(command);
        }
    }
}
