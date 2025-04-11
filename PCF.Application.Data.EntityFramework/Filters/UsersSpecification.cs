using System.Linq.Expressions;
using System.Linq;
using PFC.Domain.Entities;
using PFC.Infrastructure.Data.Repositories;

namespace PCF.Application.Data.EntityFramework.Filters;

public class UsersSpecification(string? userName, string? email, int skip, int take) : Specification<User>(skip: skip, take: take)
{
    public override Expression<Func<User, bool>>? Criteria
    {
        get
        {
            var predicates = new List<Expression<Func<User, bool>>>();
            if (!string.IsNullOrEmpty(userName))
            {
                predicates.Add(u => u.Name.Contains(userName));
            }

            if (!string.IsNullOrEmpty(email))
            {
                predicates.Add(u => u.Email.Contains(email)); 
            }
            var combinedPredicates = predicates[0];
            for (int i = 1; i < predicates.Count; i++)
            {
                //combinedPredicates = Expression.And(combinedPredicates, predicates[i]);
            }
            return combinedPredicates;
        }
    }
}