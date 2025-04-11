namespace PFC.Domain.Entities;

public class Account: TrackableEntity<Guid>
{
    public string Name { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public virtual User? User { get; set; }
    public decimal Balance { get; set; }
    public List<Transaction> Transactions { get; set; } = [];
}