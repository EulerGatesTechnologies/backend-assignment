using OT.Assessment.App.Application;
using OT.Assessment.App.Infrastructure;
using OT.Assessment.App.Models.CasinoWagers.Dtos;
using OT.Assessment.App.Models.Players.Dtos;

namespace OT.Assessment.App.Extensions
{
    public static class ModelExtensions
    {
        public static IEnumerable<PlayerCasinoWagerDto> MapToPlayerCasinoWagerDtos(this IEnumerable<CasinoWager> casinoWagers)
        {
            var playerAccountsDtos = casinoWagers
                .Select(fromCasinoWager => fromCasinoWager.ToPlayerCasinoWagerDto());

            return playerAccountsDtos;
        }

        public static PlayerAccountDto ToPlayerAccountDto(this CasinoWager casinoWager)
        {
            return new PlayerAccountDto( accountId : casinoWager.AccountId, username : casinoWager.Username );            
        }

        public static PlayerCasinoWagerDto ToPlayerCasinoWagerDto(this CasinoWager casinoWager)
        {
            //TODO: Calculate Total spend
            return new PlayerCasinoWagerDto { PlayerAccountDto = casinoWager.ToPlayerAccountDto(), TotalAmountSpend = 10 };
        }
    }
}
