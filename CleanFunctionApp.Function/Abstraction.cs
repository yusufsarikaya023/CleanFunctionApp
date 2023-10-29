using System.Net;
using MediatR;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace CleanFunctionApp.Function;

public abstract class Abstraction
{
    private readonly ILogger logger;
    private readonly IMediator mediator;

    public Abstraction(ILoggerFactory loggerFactory, IMediator mediator)
    {
        logger = loggerFactory.CreateLogger<HttpTrigger1>();
        this.mediator = mediator;
    }
    
    protected async Task<HttpResponseData> PostResponse(HttpRequestData req, IRequest request)
    {
        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "application/json; charset=utf-8");
        await mediator.Send(request);
        return response;
    }
}