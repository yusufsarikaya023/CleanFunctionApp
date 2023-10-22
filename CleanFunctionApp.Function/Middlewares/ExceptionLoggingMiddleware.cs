using System.Net;
using System.Text.Json;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker.Middleware;

namespace CleanFunctionApp.Function.Middlewares;

public class ExceptionLoggingMiddleware : IFunctionsWorkerMiddleware
{
    public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            List<string> trace = new();
            Exception? tracer = ex;
            while (tracer is not null)
            {
                    trace.Add(tracer!.Message);
                    tracer = tracer!.InnerException;
            }
            
            trace = trace.Where(x => !x.Contains("One or more errors occurred")).ToList();

            // return this response with status code 500
            var httpReqData = await context.GetHttpRequestDataAsync();
            if (httpReqData != null)
            {
                var newHttpResponse = httpReqData.CreateResponse(HttpStatusCode.InternalServerError);
                await newHttpResponse.WriteAsJsonAsync(new
                    {
                        success = false,
                        errors = JsonSerializer.Serialize(trace.ToArray())
                    },
                    newHttpResponse.StatusCode);
                context.GetInvocationResult().Value = newHttpResponse;
            }
        }
    }
}