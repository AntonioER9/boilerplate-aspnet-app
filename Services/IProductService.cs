using DTOs;

namespace Services
{
  public interface IProductService
  {
    Task<IEnumerable<ProductDto>> Get();
    Task<ProductDto> GetById(int id);
    Task<ProductDto> Add(ProductInsertDto productInsertDto);
    Task<ProductDto> Update(int id, ProductUpdateDto productUpdateDto);
    Task<ProductDto> Delete(int id);
  }

}