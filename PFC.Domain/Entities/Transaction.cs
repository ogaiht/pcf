namespace PFC.Domain.Entities;

public class Transaction : TrackableEntity<Guid>
{
    public Guid AccountId { get; set; }
    public virtual Account? Account { get; set; }
    public Guid UserId { get; set; }
    public virtual User? User { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; } = string.Empty;
}