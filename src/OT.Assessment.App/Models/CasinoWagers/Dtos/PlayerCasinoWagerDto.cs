using OT.Assessment.App.Models.Players.Dtos;

namespace OT.Assessment.App.Models.CasinoWagers.Dtos
{
    public class PlayerCasinoWagerDto
    {
        public virtual PlayerAccountDto PlayerAccountDto { get; set; }         
                
        public decimal TotalAmountSpend { get; set; }
    }
}