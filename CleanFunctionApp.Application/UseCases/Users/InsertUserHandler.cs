using AutoMapper;
using CleanFunctionApp.Application.UseCases.Users.DTO;
using CleanFunctionApp.Domain.Abstract;
using CleanFunctionApp.Domain.Aggregation.Users;
using MediatR;

namespace CleanFunctionApp.Application.UseCases.Users;

public record InsertUserCommand(UserDto Model): IRequest;

public class InsertUserHandler: IRequestHandler<InsertUserCommand>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public InsertUserHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }


    public async Task Handle(InsertUserCommand request, CancellationToken cancellationToken)
    {
        var userRepository = unitOfWork.UserRepository();
        var user = mapper.Map<User>(request.Model);
        userRepository.Insert(user);
        await unitOfWork.CommitAsync(cancellationToken);
    }
}