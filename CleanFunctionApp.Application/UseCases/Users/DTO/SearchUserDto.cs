using CleanFunctionApp.Application.Common;

namespace CleanFunctionApp.Application.UseCases.Users.DTO;

public class SearchUserDto: PaginateDto
{
    public string? Name { get; set; }
}