using CleanFunctionApp.Domain.Abstract;
using CleanFunctionApp.Domain.Aggregation.Common;

namespace CleanFunctionApp.Infrastructure.Repositories.Common;

public static class FilterExtension
{
    public static IQueryable<T> Filter<T>(this IQueryable<T> query, Specification<T>? specification) where T : Entity
    {
        if (specification is null) return query;
        return query.Where(specification.Build());
    }

    public static IQueryable<T> Paginate<T>(this IQueryable<T> query, Pagination? pagination) where T : Entity
    {
        if (pagination is null) return query;
        return query.Skip((pagination.Page - 1) * pagination.Rows).Take(pagination.Rows);
    }
}