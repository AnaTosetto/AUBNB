using AUBNB.Application.Features.Users.Commands;
using AUBNB.Domain.Features.Users;
using System.Threading.Tasks;

namespace AUBNB.Application.Features.Users
{
    public interface IUserService
    {
        Task<int> AddAsync(UserCreateCommand command);
        Task<bool> UpdateAsync(UserUpdateCommand command);
        Task<User> VerifyLoginAsync(UserLoginCommand command);
        Task<User> GetById(int id);
    }
}
