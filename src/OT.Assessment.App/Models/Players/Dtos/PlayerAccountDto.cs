using OT.Assessment.App.Models.CasinoWagers.Dtos;
using OT.Assessment.Core.Entities;

namespace OT.Assessment.App.Models.Players.Dtos
{
    public class PlayerAccountDto(string accountId, string username)
    {
        public string AccountId { get;  } = accountId;
        public string Username { get;  } = username;

        public ICollection<double> Amounts { get; set; }
    }
}
