using System.Globalization;

using System.Data;
using Dapper;
using OT.Assessment.Core;

namespace OT.Assessment.App
{
    public class PlayerOptions
    {
        public const string ApiUrlBase = "/api/player/";

        public const string ApiVersion = "api-vesrion=1.0"; // Set by hosting environment
        private string apiUrlCasinoPlayersFormat = "{playerId}/casino";

        public string GetApiUrlCasinoPlayersFormat()
        {
            return apiUrlCasinoPlayersFormat;
        }

        public void SetApiUrlCasinoPlayersFormat(string value)
        {
            apiUrlCasinoPlayersFormat = value;
        }

        public string? ApiUrlBaseAddress { get; set; } // Set by hosting environment
        public const string ApiUrlCasinoPlayersFormat = "{playerId}/casino";

        public string GetFullPlayerApiUlr(string playerId)
        {
            // PERF: Not ideal
            return @$"{ApiUrlBaseAddress}{ApiUrlBase}{ApiUrlCasinoPlayersFormat()}}{}";
        }

       
    }
}
