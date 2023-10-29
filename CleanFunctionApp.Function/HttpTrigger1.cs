// using System.Net;
// using System.Text.Json;
// using CleanFunctionApp.Application.UseCases.Users;
// using CleanFunctionApp.Infrastructure;
// using MediatR;
// using Microsoft.Azure.Functions.Worker;
// using Microsoft.Azure.Functions.Worker.Http;
// using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
// using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
// using Microsoft.Extensions.Logging;
// using Microsoft.OpenApi.Models;
//
// namespace CleanFunctionApp.Function;
//
// public class HttpTrigger1
// {
//     private readonly ILogger logger;
//     private readonly IMediator mediator;
//
//     public HttpTrigger1(ILoggerFactory loggerFactory, IMediator mediator)
//     {
//         logger = loggerFactory.CreateLogger<HttpTrigger1>();
//         this.mediator = mediator;
//     }
//
//     [Function("HttpTrigger1")]
//     [OpenApiOperation(operationId: "selectAllJpbs", tags: new[] { "TctJob" }, Summary = "Select all jobs.", Description = "This select all the jobs of an agent.", Visibility = OpenApiVisibilityType.Important)]
//     //[OpenApiSecurity("petstore_auth", SecuritySchemeType.OAuth2, Flows = typeof(PetStoreAuth))]
//     [OpenApiParameter(name: "agentId", In = ParameterLocation.Query, Description = "The id of the agent to download the jobs", Required = true, Type = typeof(Guid))]
//     [OpenApiRequestBody(contentType: "application/json", bodyType: typeof(string), Required = true, Description = "List of all the jobs of the requested agent.")]
//     [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(string), Summary = "Job list.", Description = "List of all the jobs.")]
//     public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
//     {
//         logger.LogInformation("yusuf C# HTTP trigger function processed a request.");
//
//         var response = req.CreateResponse(HttpStatusCode.OK);
//         response.Headers.Add("Content-Type", "application/json; charset=utf-8");
//
//         var users = await mediator.Send(new SearchUserRequest());
//
//         var json = JsonSerializer.Serialize(users);
//         response.WriteString(json);
//         return response;
//     }
// }