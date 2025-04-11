using PFC.Infrastructure.DataModels.Entities;

namespace PFC.Domain.Entities;

public abstract class TrackableEntity<TId> : BaseEntity<TId>, ITrackableEntity
{
    public virtual DateTime CreatedOn { get; set; }
    public virtual DateTime ModifiedOn { get; set; }
}