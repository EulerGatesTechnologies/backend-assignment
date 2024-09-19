using OT.Assessment.Data;

namespace OT.Assessment.App.Services;

public class CasinoWagerService(IRepository repository)
{
    public async Task AddCasinoWagerAsync(PlayerCasinoWager wager)
    {
        await repository.AddPlayerCasinoWagerAsync(wager);
    }
}
