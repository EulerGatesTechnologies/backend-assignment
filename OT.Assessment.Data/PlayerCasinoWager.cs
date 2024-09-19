namespace OT.Assessment.Data;

public class PlayerCasinoWager
{
    public Guid Id { get; set; }
    public Guid PlayerAccountId { get; set; }
    public string Game { get; set; }
    public string Provider { get; set; }
    public decimal Amount { get; set; }
    public DateTime CreatedDateTime { get; set; }
}
