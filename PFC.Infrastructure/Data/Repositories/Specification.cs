using System.Linq.Expressions;

namespace PFC.Infrastructure.Data.Repositories;

public abstract class Specification<TEntity>(bool isPagingEnabled = true, int skip = 0, int take = 0) : ISpecification<TEntity>
{
    public virtual Expression<Func<TEntity, bool>>? Criteria => null;
    public virtual List<Expression<Func<TEntity, object>>>? Includes => null;
    public virtual Expression<Func<TEntity, object>>? OrderBy => null;
    public virtual Expression<Func<TEntity, object>>? OrderByDescending => null;
    public int Take => take;
    public int Skip => skip;
    public bool IsPagingEnabled => isPagingEnabled;
}