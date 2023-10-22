namespace CleanFunctionApp.Domain.Aggregation.Common;

public class Sucess : Response
{
    public Sucess(): base(true)
    {
        
    }
}

public class Success<T>
{
    public T Body { get; set; }
    public int Size { get; set; }

    public Success(T body) => Body = body;
    
    public Success(T body, int size) => (Body, Size) = (body, size);
}