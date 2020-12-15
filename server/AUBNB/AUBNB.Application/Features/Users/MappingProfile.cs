using AUBNB.Application.Features.Users.Commands;
using AUBNB.Domain.Features.Users;
using AutoMapper;

namespace AUBNB.Application.Features.Users
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserCreateCommand, User>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<UserUpdateCommand, User>();

            CreateMap<UserLoginCommand, User>();
        }
    }
}
