namespace CleanFunctionApp.Application.Common;

public class PaginateDto: EntityDto
{
    public int Page { get; set; }
    public int Size { get; set; }
    
    // Deconstructing assignment
    public void Deconstruct(out int page, out int size) => (page, size) = (Page, Size);
}