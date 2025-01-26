using AutoMapper;
using OT.Assessment.Core.Entities;

namespace OT.Assessment.App.DomainModels.Players.Dtos
{
    public class PlayerAccountMapProfile : Profile
    {
        public PlayerAccountMapProfile()
        {
            CreateMap<PlayerAccountDto, PlayerAccount>();
            

            
        }
    }
}

