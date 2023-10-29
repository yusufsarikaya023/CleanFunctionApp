using CleanFunctionApp.Application.UseCases.Users.DTO;
using CleanFunctionApp.Domain.Abstract;
using CleanFunctionApp.Domain.Aggregation.Common;
using CleanFunctionApp.Domain.Aggregation.Users;
using MediatR;

namespace CleanFunctionApp.Application.UseCases.Users;

public record SearchUserRequest(SearchUserDto Dto): IRequest<User[]>;

public class SearchUser: Handler, IRequestHandler<SearchUserRequest,User[]>
{
    private readonly IUnitOfWork unitOfWork;

    public SearchUser(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
    public Task<User[]> Handle(SearchUserRequest request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;
        var users =   this.unitOfWork.UserRepository();
        return Success(users.Search());
    }
}