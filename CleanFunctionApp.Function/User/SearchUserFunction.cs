using System.Net;
using CleanFunctionApp.Application.UseCases.Users;
using CleanFunctionApp.Application.UseCases.Users.DTO;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.OpenApi.Models;

namespace CleanFunctionApp.Function.User;

public class SearchUserFunction: Abstraction
{
    public SearchUserFunction(IMediator mediator) : base(mediator)
    {
    }

    [Function("SearchUser")]
    [Authorize("Admin")]
    [OpenApiSecurity("bearer_auth", SecuritySchemeType.Http, Scheme = OpenApiSecuritySchemeType.Bearer,BearerFormat = "JWT")]
    [OpenApiOperation(operationId: "Get User By Filter", tags: new[] { "User" }, Summary = "Search New User.", Description = "Operation Insert new user to database.", Visibility = OpenApiVisibilityType.Important)]
    [OpenApiRequestBody(contentType: "application/json", bodyType: typeof(SearchUserDto), Required = true, Description = "Add new user to database.")]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(string), Summary = "Job list.", Description = "List of all the jobs.")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req) =>
         await PostResponse(
            req,new SearchUser(req.Convert<SearchUserDto>())
        );
}