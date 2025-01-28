namespace OT.Assessment.App
{
    public class PlayerOptions
    {
        public const string ApiUrlBase = "/api/player/";

        public const string ApiVersion = "api-version=1.0"; // Set by hosting environment

        public string ApiUrlHostAddress { get; set; } = "http://localhost:5021/api/";

        public const string ApiUrlCasinoPlayersFormat = "{playerId}/casino";

        public string GetFullPlayerApiUlr(string playerId)
        {
            // PERF: Not ideal
            return @$"{ApiUrlHostAddress}{ApiUrlBase}{ApiUrlCasinoPlayersFormat}";
        }       
    }
}
