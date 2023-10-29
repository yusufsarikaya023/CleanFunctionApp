namespace CleanFunctionApp.Domain.Aggregation.Common;

public class Response
{
    public bool Success { get; set; }
    public Response(bool success = true) => Success = success;
}