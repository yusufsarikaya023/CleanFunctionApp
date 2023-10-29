using FluentValidation;

namespace CleanFunctionApp.Application.Abstract;

public interface IValidateable<T>
{
    AbstractValidator<T> Validator { get; }
}