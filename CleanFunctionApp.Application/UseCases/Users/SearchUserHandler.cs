using CleanFunctionApp.Application.UseCases.Users.DTO;
using CleanFunctionApp.Domain.Abstract;
using CleanFunctionApp.Domain.Aggregation.Common;
using CleanFunctionApp.Domain.Aggregation.Users;
using MediatR;

namespace CleanFunctionApp.Application.UseCases.Users;

public record SearchUser(SearchUserDto Dto): IRequest<User[]>;

public class SearchUserHandler: Handler, IRequestHandler<SearchUser,User[]>
{
    private readonly IUnitOfWork unitOfWork;

    public SearchUserHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
    public Task<User[]> Handle(SearchUser request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;
        var (page, rows) = dto;
        Pagination pagination = new(page,rows);
        UserSpecification specification = new(dto);
        var users =   unitOfWork.UserRepository();
        return Success(users.Search(specification,pagination));
    }
}