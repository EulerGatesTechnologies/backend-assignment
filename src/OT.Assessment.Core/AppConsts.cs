
using System.Configuration;

namespace OT.Assessment.Core
{    public class AppConsts

    {
        public const string PlayerEvents = "PlayerEvents";

        public const string ConnectionStringName = "OT_Assessment_DB";

        public static string GetConnectionString(string name = ConnectionStringName)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

    }
}
