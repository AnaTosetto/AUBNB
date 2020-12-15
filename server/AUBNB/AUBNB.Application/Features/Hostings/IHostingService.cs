using AUBNB.Application.Features.Hostings.Commands;
using AUBNB.Domain.Features.Hostings;
using System.Linq;
using System.Threading.Tasks;

namespace AUBNB.Application.Features.Hostings
{
    public interface IHostingService
    {
        IQueryable<Hosting> GetAll(int userId);

        Task<Hosting> GetById(int id);

        Task<int> AddAsync(HostingCreateCommand command);
    }
}
