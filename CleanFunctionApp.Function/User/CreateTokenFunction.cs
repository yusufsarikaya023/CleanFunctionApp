using System.Net;
using System.Text;
using CleanFunctionApp.Application.UseCases.Users.DTO;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using CleanFunctionApp.Domain.Abstract;


namespace CleanFunctionApp.Function.User;

public class CreateTokenFunction: Abstraction<InsertUserFunction>
{
    private readonly IJwtService jwtService;

    public CreateTokenFunction(ILoggerFactory loggerFactory, IMediator mediator, IJwtService jwtService):base(loggerFactory, mediator)
    {
        this.jwtService = jwtService;
    }

    [Function("CreateToken")]
    [OpenApiOperation(operationId: "selectAllJpbs", tags: new[] { "User" }, Summary = "Create token.",
        Description = "Operation Insert new user to database.", Visibility = OpenApiVisibilityType.Important)]
    [OpenApiRequestBody(contentType: "application/json", bodyType: typeof(UserDto), Required = true,
        Description = "Add new user to database.")]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(string),
        Summary = "Job list.", Description = "List of all the jobs.")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
    {
        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "application/json; charset=utf-8");
        var token = jwtService.BuildToken(new List<Claim>()
        {
            new(ClaimTypes.Name, "admin"),
            new(ClaimTypes.Role, "admin"),
            new(ClaimTypes.Email, "test@test.com")
        });
        await response.WriteStringAsync(token);
        return response;
    }
}
