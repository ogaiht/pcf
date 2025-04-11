namespace PFC.Domain.Entities;

public class Category: TrackableEntity<Guid>
{
    public string Name { get; set; } = string.Empty;
}