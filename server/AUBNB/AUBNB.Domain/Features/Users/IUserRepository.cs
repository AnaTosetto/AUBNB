using System.Threading.Tasks;
using AUBNB.Infra.Security;

namespace AUBNB.Domain.Features.Users
{
    public interface IUserRepository
    {
        Task<User> AddAsync(User user);
        Task<bool> UpdateAsync(User user);
        Task<bool> IsUniqueAsync(string email);
        Task<User> GetByPasswordAndEmailAsync(string password, string email,IEncrypter encrypter);
        Task<User> GetById(int id);
    }
}