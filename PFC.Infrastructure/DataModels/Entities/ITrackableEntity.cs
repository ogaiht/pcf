namespace PFC.Infrastructure.DataModels.Entities;

public interface ITrackableEntity
{
    DateTime CreatedOn { get; set; }
    DateTime ModifiedOn { get; set; }
}