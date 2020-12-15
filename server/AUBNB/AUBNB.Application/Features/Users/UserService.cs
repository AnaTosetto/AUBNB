using AUBNB.Application.Features.Users.Commands;
using AUBNB.Domain.Features.Users;
using AutoMapper;
using System;
using System.Threading.Tasks;
using AUBNB.Infra.Security;

namespace AUBNB.Application.Features.Users
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;
        private readonly IEncrypter _encrypter;

        public UserService(IUserRepository userRepository, IEncrypter encrypter)
        {
            _userRepository = userRepository;
            _encrypter = encrypter;
        }

        public async Task<int> AddAsync(UserCreateCommand command)
        {   
            var isUnique = await _userRepository.IsUniqueAsync(command.Email);

            if (isUnique)
            {
                throw new Exception("Não foi possível cadastrar o usuário, pois já existe um usuário cadastrado com esse email!");
            }

            var user = Mapper.Map<User>(command);
            user.SetPassword(command.Password, _encrypter);
            var addResult = await _userRepository.AddAsync(user);

            return addResult.Id;
        }

        public async Task<bool> UpdateAsync(UserUpdateCommand command)
        {
            var user = Mapper.Map<User>(command);
            user.SetPassword(command.Password, _encrypter);
            var updateResult = await _userRepository.UpdateAsync(user);

            return updateResult;
        }

        public async Task<User> VerifyLoginAsync(UserLoginCommand command)
        {
            var user = await _userRepository.GetByPasswordAndEmailAsync(command.Password, command.Email,_encrypter);

            if (user is null)
            {
                throw new Exception("Não foi possível logar, email ou senha estão incorretos!");
            }

            return user;
        }

        public Task<User> GetById(int id)
        {
            return _userRepository.GetById(id);
        }
    }
}
