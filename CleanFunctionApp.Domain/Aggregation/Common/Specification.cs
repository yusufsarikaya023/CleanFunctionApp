using System.Linq.Expressions;

namespace CleanFunctionApp.Domain.Aggregation.Common;

public abstract class Specification<T> where T : Entity
{
    public abstract Expression<Func<T, bool>> Build();
}