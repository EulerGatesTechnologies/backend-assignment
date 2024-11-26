
using System.Configuration;

namespace OT.Assessment.Common
{
    public static class Tools
    {
        // TODO - Fix packagae missing below error since we offline for now
        public static string GetConnectionString(string name = "OT_Assessment_DB")
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
