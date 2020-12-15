using AUBNB.Domain.Features.Users;
using AUBNB.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using AUBNB.Infra.Security;

namespace AUBNB.Infra.Data.Features.Users
{
    public class UserRepository : IUserRepository
    {
        private AUBNBDbContext _context;

        public UserRepository(AUBNBDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddAsync(User user)
        {
            var newUser = _context.Users.Add(user).Entity;

            await _context.SaveChangesAsync();

            return newUser;
        }

        public async Task<bool> UpdateAsync(User user)
        {
            _context.Entry(user).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> IsUniqueAsync(string email)
        {
           return await _context.Users.AnyAsync(x => x.Email == email);
        }

        public async Task<User> GetByPasswordAndEmailAsync(string password, string email, IEncrypter encrypter)
        {
            var result = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            return result.ValidatePassword(password, encrypter) ? result : null;
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
