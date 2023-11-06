using CleanFunctionApp.Application.Services;
using CleanFunctionApp.Domain.Abstract;
using MediatR;

namespace CleanFunctionApp.Application.UseCases.Users;

public record LoginUser(string Email, string Password) : IRequest<string>;

public class LoginUserHandler : Handler, IRequestHandler<LoginUser, string>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IJwtService jwtService;

    public LoginUserHandler(IUnitOfWork unitOfWork, IJwtService jwtService)
    {
        this.unitOfWork = unitOfWork;
        this.jwtService = jwtService;
    }

    public Task<string> Handle(LoginUser request, CancellationToken cancellationToken)
    {
        var userRepository = unitOfWork.UserRepository();
        var user = userRepository.GetByEmail(request.Email);
        if (user == null) throw new Exception("Invalid_Email");
        if (user.Password != request.Password) throw new Exception("Invalid_Password");

        var tokens = ClaimBuilder.Create()
            .SetEmail(user.Email)
            .SetRole(user.Role)
            .SetId(user.Id.ToString())
            .Build();
        var token = jwtService.BuildToken(tokens);
        return Success(token);
    }
}