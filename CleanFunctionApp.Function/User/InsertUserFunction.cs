using System.Net;
using CleanFunctionApp.Application.UseCases.Users;
using CleanFunctionApp.Domain.Aggregation.Users.DTO;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace CleanFunctionApp.Function.User;

public class InsertUserFunction
{
    private readonly ILogger _logger;
    private readonly IMediator mediator;

    public InsertUserFunction(ILoggerFactory loggerFactory, IMediator mediator)
    {
        _logger = loggerFactory.CreateLogger<HttpTrigger1>();
        this.mediator = mediator;
    }
    
    [Function("InsertUser")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
    {
        _logger.LogInformation("yusuf C# HTTP trigger function processed a request.");
        
        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "application/json; charset=utf-8");
        
        var dto = await req.ReadFromJsonAsync<UserDto>();
        
        await mediator.Send(new InsertUserCommand(dto!));
        return response;
    }
}