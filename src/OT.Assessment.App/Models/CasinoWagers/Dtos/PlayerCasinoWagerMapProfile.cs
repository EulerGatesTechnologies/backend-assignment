using AutoMapper;
using OT.Assessment.Core.Entities;

namespace OT.Assessment.App.Models.CasinoWagers.Dtos
{
    public class PlayerCasinoWagerMapProfile : Profile
    {
        public PlayerCasinoWagerMapProfile()
        {
            CreateMap<PlayerCasinoWager, PlayerCasinoWagerDto>();
        }
    }
}

