using CleanFunctionApp.Domain.Aggregation.Common;

namespace CleanFunctionApp.Application.Common;

public abstract class SpecialSpecification<T,TSearchDto> : Specification<T> where T : Entity where TSearchDto : EntityDto
{
    public TSearchDto? SearchDto { get; set; }
    public SpecialSpecification(TSearchDto? searchDto) => SearchDto = searchDto;
    
    public bool IsNull() => SearchDto == null;
}