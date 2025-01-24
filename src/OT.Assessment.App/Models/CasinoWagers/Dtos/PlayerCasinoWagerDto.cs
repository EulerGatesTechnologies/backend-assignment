using System.Text.Json.Serialization;

namespace OT.Assessment.App.Models.CasinoWagers.Dtos
{
    public class PlayerCasinoWagerDto
    {
        [JsonPropertyName("accountId")]
        public string AccountId { get; set; }

        [JsonPropertyName("Username")]
        public string Username { get; set; }

        [JsonPropertyName("externalReferenceId")]
        public string ExternalReferenceId { get; set; }

        [JsonPropertyName("transactionTypeId")]
        public string TransactionTypeId { get; set; }

        [JsonPropertyName("amount")]
        public double Amount { get; set; }

        [JsonPropertyName("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }

        [JsonPropertyName("numberOfBets")]
        public int NumberOfBets { get; set; }

        [JsonPropertyName("countryCode")]
        public string CountryCode { get; set; }

        [JsonPropertyName("sessionData")]
        public string SessionData { get; set; }

        [JsonPropertyName("Duration")]
        public long Duration { get; set; }
    }
}