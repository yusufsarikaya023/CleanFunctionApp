using CleanFunctionApp.Application.Abstract;

namespace CleanFunctionApp.Application.Common;

public static class ValidationExtensions
{
    public static bool IsValid<T>(this IValidateable<T> obj)
    {
        return obj.Validator.Validate((T)obj).IsValid;
    }
}