using AutoMapper;
using OT.Assessment.Core.Entities;

namespace OT.Assessment.App.Models.Players.Dtos
{
    public class PlayerAccountMapProfile : Profile
    {
        public PlayerAccountMapProfile()
        {
            CreateMap<PlayerAccount, PlayerAccountDto>();            
        }
    }
}

