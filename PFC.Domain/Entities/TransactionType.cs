namespace PFC.Domain.Entities;

public class TransactionType : TrackableEntity<Guid>
{
    public string Name { get; set; } = string.Empty;
}