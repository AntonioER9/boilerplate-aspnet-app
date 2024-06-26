using AutoMapper;
using DTOs;
using Models;


namespace Automappers
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<ProductInsertDto, Product>();
      CreateMap<Product, ProductDto>()
        .ForMember(dto => dto.Id,
                   m => m.MapFrom(product => product.ProductID));
      CreateMap<ProductUpdateDto, Product>();
    }
  }
}