using CleanFunctionApp.Domain.Abstract;
using CleanFunctionApp.Domain.Aggregation.Users;
using MediatR;

namespace CleanFunctionApp.Application.UseCases.Users;

public record SearchUserRequest(): IRequest<User[]>;

public class SearchUser: IRequestHandler<SearchUserRequest,User[]>
{
    private readonly IUnitOfWork unitOfWork;

    public SearchUser(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
    public Task<User[]> Handle(SearchUserRequest request, CancellationToken cancellationToken)
    {
        var users =   this.unitOfWork.UserRepository();
        return Task.FromResult(users.Search());
    }
}