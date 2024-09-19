using System;

namespace OT.Assessment.App.Services;

public class CasinoWagerService
{
    private readonly IRepository _repository;

    public CasinoWagerService(IRepository repository)
    {
        _repository = repository;
    }

    public async Task AddCasinoWagerAsync(PlayerCasinoWager wager)
    {
        await _repository.AddPlayerCasinoWagerAsync(wager);
    }
}
