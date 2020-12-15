using AUBNB.Application.Features.Hostings.Commands;
using AUBNB.Domain.Features.Hostings;
using AUBNB.Domain.Features.Users;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;

namespace AUBNB.Application.Features.Hostings
{
    public class HostingService : IHostingService
    {
        IHostingRepository _hostingsRepository;
        IUserRepository _userRepository;

        public HostingService(IHostingRepository hostingsRepository, IUserRepository userRepository)
        {
            _hostingsRepository = hostingsRepository;
            _userRepository = userRepository;
        }

        public IQueryable<Hosting> GetAll(int userId)
        {
            return _hostingsRepository.GetAll(userId);
        }

        public Task<Hosting> GetById(int id)
        {
            return _hostingsRepository.GetById(id);
        }

        public async Task<int> AddAsync(HostingCreateCommand command)
        {
            var user = await _userRepository.GetById(command.UserId);

            var hosting = Mapper.Map<Hosting>(command);

            hosting.User = user;
            hosting.Availability = true;
            hosting.Note = 5;

            var addResult = await _hostingsRepository.AddAsync(hosting);

            return addResult.Id;
        }
    }
}
