using System.Globalization;

namespace OT.Assessment.App
{
    public class PlayerOptions
    {
        public string ApiBasePath { get; set; } = "/api/v1/player/";

        public string? PicBaseAddress { get; set; } // Set by hosting environment

        public string PicBasePathFormat { get; set; } = "items/{0}/pic/";

        public string GetPictureUrl(int catalogItemId)
        {
            // PERF: Not ideal
            return PicBaseAddress + ApiBasePath + string.Format(CultureInfo.InvariantCulture, PicBasePathFormat, catalogItemId);
        }
    }
}
