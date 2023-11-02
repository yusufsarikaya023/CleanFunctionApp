namespace CleanFunctionApp.Domain.Abstract;

public interface IPasswordHashService
{
    string ComputeSha256Hash(string rawData);
}