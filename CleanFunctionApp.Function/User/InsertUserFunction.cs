using System.Net;
using CleanFunctionApp.Application.UseCases.Users;
using CleanFunctionApp.Application.UseCases.Users.DTO;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace CleanFunctionApp.Function.User;

public class InsertUserFunction: Abstraction
{

    public InsertUserFunction(ILoggerFactory loggerFactory, IMediator mediator):base(loggerFactory, mediator)
    {
    }
    
    [Function("InsertUser")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req) =>
        await PostResponse(
            req,new InsertUserCommand(req.Convert<UserDto>())
            );
}