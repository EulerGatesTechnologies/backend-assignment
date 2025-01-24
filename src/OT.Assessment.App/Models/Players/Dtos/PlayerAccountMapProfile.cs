using AutoMapper;

namespace OT.Assessment.App.DomainModels.Players.Dtos
{
    public class PlayerAccountMapProfile : Profile
    {
        public PlayerAccountMapProfile()
        {
            CreateMap<PlayerAccountDto, PlayerAccount>();
            CreateMap<PlayerAccountDto, PlayerAccount>()
                .ForMember(x => x.Roles, opt => opt.Ignore())
                .ForMember(x => x.CreationTime, opt => opt.Ignore());

            CreateMap<CreateUserDto, User>();
            CreateMap<CreateUserDto, User>().ForMember(x => x.Roles, opt => opt.Ignore());
        }
    }
}

