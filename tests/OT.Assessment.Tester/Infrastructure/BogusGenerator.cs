using OT.Assessment.App.Infrastructure;

namespace OT.Assessment.Tester.Infrastructure;

public class BogusGenerator
{
    private readonly List<Player> _testPlayers;
    private readonly List<Provider> _testProviders;
    private readonly Faker<CasinoWager> _testCasinoWagerFaker;

    public BogusGenerator()
    {
        Randomizer.Seed = new Random(1010);

        var themes = new[] { "ancient", "adventure", "wildlife", "jungle", "retro", "family", "crash" };

        _testPlayers = new Faker<Player>()          
           .StrictMode(true)          
           .RuleFor(o => o.Username, f => f.Person.UserName)           
           .RuleFor(o => o.AccountId, f => f.Random.Guid())
           .Generate(1000);


        _testProviders = new Faker<Provider>()
           .StrictMode(true)
           .RuleFor(o => o.Name, f => f.Commerce.ProductName())
           .RuleFor(o => o.Games, f => new Faker<Game>()
               .RuleFor(of => of.Name, ff => f.Commerce.ProductName())
               .RuleFor(of => of.Theme, ff => ff.PickRandom(themes))
               .Generate(10))
           .Generate(100);

        _testCasinoWagerFaker = new Faker<CasinoWager>()
            .StrictMode(true)
            .RuleFor(o => o.SessionData, f => f.Random.Words(20))
            .RuleFor(o => o.WagerId, () => Guid.NewGuid().ToString())
            .RuleFor(o => o.Provider, (f, u) => f.PickRandom(_testProviders).Name)
            .RuleFor(o => o.GameName, (f, u) => f.PickRandom(_testProviders.First(x => x.Name == u.Provider).Games).Name)
            .RuleFor(o => o.Theme,
                (f, u) => f.PickRandom(_testProviders.First(x => x.Name == u.Provider).Games
                    .First(x => x.Name == u.GameName)).Theme)
            .RuleFor(o => o.TransactionId, () => Guid.NewGuid().ToString())
            .RuleFor(o => o.BrandId, () => Guid.NewGuid().ToString())
            .RuleFor(o => o.Username, f => f.PickRandom(_testPlayers).Username.ToString())
            .RuleFor(o => o.AccountId, (f, u) => f.PickRandom(_testPlayers.FirstOrDefault(x => x.Username == u.Username)).AccountId.ToString())
            .RuleFor(o => o.ExternalReferenceId, () => Guid.NewGuid().ToString())
            .RuleFor(o => o.TransactionTypeId, () => Guid.NewGuid().ToString())
            .RuleFor(o => o.CreatedDateTime, f => f.Date.Past())
            .RuleFor(o => o.NumberOfBets, f => f.Random.Int(1, 10))
            .RuleFor(o => o.CountryCode, f => f.Address.CountryCode())
            .RuleFor(o => o.Duration, f => f.Random.Long(10000, 3600000))
            .RuleFor(o => o.Amount, f => f.Random.Double(10, 50000));

    }

    public List<CasinoWager> Generate()
    {       
        var fakePlayerCasinoWagers = _testCasinoWagerFaker.Generate(10000);

        return fakePlayerCasinoWagers;

    }
}