using AutoMapper;
using CleanFunctionApp.Application.UseCases.Users.DTO;
using CleanFunctionApp.Domain.Abstract;
using CleanFunctionApp.Domain.Aggregation.Users;
using MediatR;

namespace CleanFunctionApp.Application.UseCases.Users;

public record InsertUserCommand(UserDto Model) : IRequest;

public class InsertUserHandler : Handler, IRequestHandler<InsertUserCommand>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly IPasswordHashService passwordHashService;

    public InsertUserHandler(IUnitOfWork unitOfWork, IMapper mapper, IPasswordHashService passwordHashService)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.passwordHashService = passwordHashService;
    }

    public async Task Handle(InsertUserCommand request, CancellationToken cancellationToken)
    {
        var userRepository = unitOfWork.UserRepository();
        var user = mapper.Map<User>(request.Model);
        user.Password = passwordHashService.ComputeSha256Hash(user.Password);
        userRepository.Insert(user);
        await unitOfWork.CommitAsync(cancellationToken);
    }
}