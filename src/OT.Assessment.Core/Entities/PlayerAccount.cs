using System.Text.Json.Serialization;

namespace OT.Assessment.Core.Entities;

public class PlayerAccount
{
    [JsonPropertyName("accountId")]
    public Guid AccountId { get; set; }

    [JsonPropertyName("username")]
    public string Username { get; set; }
}