using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using CleanFunctionApp.Infrastructure;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace CleanFunctionApp.Function;

public class HttpTrigger1
{
    private readonly ILogger _logger;
    private readonly Context context;

    public HttpTrigger1(ILoggerFactory loggerFactory, Context context)
    {
        this.context = context;
        _logger = loggerFactory.CreateLogger<HttpTrigger1>();
    }
    
    [Function("HttpTrigger1")]
    public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
    {
        _logger.LogInformation("yusuf C# HTTP trigger function processed a request.");
        
        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "application/json; charset=utf-8");
        // return user list in this response    
        
        var users = context.Users.ToList();
        var json = JsonSerializer.Serialize(users);
        response.WriteString(json);
        return response;
    }
}