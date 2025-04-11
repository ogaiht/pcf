namespace PFC.Infrastructure.DataModels.Entities;

public interface IEntity<TId>
{
    TId Id { get; set; }
}