using System.Linq;
using System.Threading.Tasks;

namespace AUBNB.Domain.Features.Hostings
{
    public interface IHostingRepository
    {
        IQueryable<Hosting> GetAll(int userId);
        Task<Hosting> GetById(int id);
        Task<Hosting> AddAsync(Hosting hosting);
    }
}
