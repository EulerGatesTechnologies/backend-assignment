
using System.Configuration;

namespace OT.Assessment.Core
{    public class AppConsts

    {
        public const string PlayerEvents = "PlayerEvents";

        public static string GetConnectionString(string dbName = "OT_Assessment_DB")
        {
            return ConfigurationManager.ConnectionStrings[dbName].ConnectionString;
        }

    }
}
