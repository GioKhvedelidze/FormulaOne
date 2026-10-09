using AutoMapper;
using FormulaOne.Api.MappingProfiles;

namespace FormulaOne.Tests;

internal static class TestMapper
{
    public static IMapper Create() => new MapperConfiguration(cfg =>
    {
        cfg.AddProfile<DomainToResponse>();
        cfg.AddProfile<RequestToDomain>();
    }).CreateMapper();
}