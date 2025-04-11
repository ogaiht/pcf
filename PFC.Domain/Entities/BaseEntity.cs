using PFC.Infrastructure.DataModels.Entities;

namespace PFC.Domain.Entities;

public abstract class BaseEntity<TId>  : IEntity<TId>
{
    public virtual TId? Id { get; set; }
}