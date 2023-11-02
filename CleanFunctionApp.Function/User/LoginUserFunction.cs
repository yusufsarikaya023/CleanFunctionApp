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
using CleanFunctionApp.Application.UseCases.Users;
using CleanFunctionApp.Domain.Abstract;


namespace CleanFunctionApp.Function.User;

public class LoginUserFunction: Abstraction<InsertUserFunction>
{

    public LoginUserFunction(ILoggerFactory loggerFactory, IMediator mediator):base(loggerFactory, mediator)
    {
    }

    [Function("LoginUser")]
    [OpenApiOperation(operationId: "selectAllJpbs", tags: new[] { "User" }, Summary = "Create token.", Description = "Create new token.", Visibility = OpenApiVisibilityType.Important)]
    [OpenApiRequestBody(contentType: "application/json", bodyType: typeof(LoginUser), Required = true, Description = "Create new token for user.")]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(string), Summary = "Create token.", Description = "Create Token")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req) => 
        await PostResponse(
            req,req.Convert<LoginUser>()
        );
}
