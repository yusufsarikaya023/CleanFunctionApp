using System.Linq.Expressions;
using CleanFunctionApp.Application.Common;
using CleanFunctionApp.Domain.Aggregation.Users;

namespace CleanFunctionApp.Application.UseCases.Users.DTO;

public class UserSpecification : SpecialSpecification<User, SearchUserDto>
{
    public UserSpecification(SearchUserDto searchDto) : base(searchDto)
    {
    }

    public override Expression<Func<User, bool>> Build() => 
        e => IsNull() || e.Name.Contains(SearchDto!.Name!); 
}