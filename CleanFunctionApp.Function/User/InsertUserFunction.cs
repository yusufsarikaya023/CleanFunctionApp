using System.Net;
using CleanFunctionApp.Application.UseCases.Users;
using CleanFunctionApp.Application.UseCases.Users.DTO;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;

namespace CleanFunctionApp.Function.User;

public class InsertUserFunction: Abstraction<InsertUserFunction>
{

    public InsertUserFunction(ILoggerFactory loggerFactory, IMediator mediator):base(loggerFactory, mediator)
    {
    }
    
    [Function("InsertUser")]
    [OpenApiOperation(operationId: "selectAllJpbs", tags: new[] { "User" }, Summary = "Insert New User.", Description = "Operation Insert new user to database.", Visibility = OpenApiVisibilityType.Important)]
    [OpenApiRequestBody(contentType: "application/json", bodyType: typeof(UserDto), Required = true, Description = "Add new user to database.")]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(string), Summary = "Job list.", Description = "List of all the jobs.")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req) =>
        await PostResponse(
            req,new InsertUserCommand(req.Convert<UserDto>())
            );
}