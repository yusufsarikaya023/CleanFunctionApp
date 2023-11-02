using MediatR;

namespace CleanFunctionApp.Application;

public abstract class Handler
{
  public static Task<T> Success<T>(T dto)  => Task.FromResult(dto);
}