using System.Net;
using System.Text.Json;
using CleanFunctionApp.Application.UseCases.Users;
using CleanFunctionApp.Infrastructure;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace CleanFunctionApp.Function;

public class HttpTrigger1
{
    private readonly ILogger logger;
    private readonly IMediator mediator;

    public HttpTrigger1(ILoggerFactory loggerFactory, IMediator mediator)
    {
        logger = loggerFactory.CreateLogger<HttpTrigger1>();
        this.mediator = mediator;
    }
    
    [Function("HttpTrigger1")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
    {
        logger.LogInformation("yusuf C# HTTP trigger function processed a request.");
        
        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "application/json; charset=utf-8");

        var users = await mediator.Send(new SearchUserRequest());
        
        var json = JsonSerializer.Serialize(users);
        response.WriteString(json);
        return response;
    }
}