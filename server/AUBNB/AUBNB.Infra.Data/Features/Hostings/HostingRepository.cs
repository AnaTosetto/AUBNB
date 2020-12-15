using AUBNB.Domain.Features.Hostings;
using AUBNB.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AUBNB.Infra.Data.Features.Hostings
{
    public class HostingRepository : IHostingRepository
    {
        private AUBNBDbContext _context;

        public HostingRepository(AUBNBDbContext context)
        {
            _context = context;
        }

        public IQueryable<Hosting> GetAll(int userId)
        {
            return _context.Hostings.Include(x => x.User).Where(x => x.Availability && x.UserId != userId).AsQueryable();
        }

        public async Task<Hosting> GetById(int id)
        {
            return await _context.Hostings.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Hosting> AddAsync(Hosting hosting)
        {
            var newHosting = _context.Hostings.Add(hosting).Entity;

            await _context.SaveChangesAsync();

            return newHosting;
        }
    }
}
