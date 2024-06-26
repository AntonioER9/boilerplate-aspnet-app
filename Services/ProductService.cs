using DTOs;

namespace Services
{
  public class ProductService : ICommonService<ProductDto, ProductInsertDto, ProductUpdateDto>
  {

    private DatabaseContext _context;
    public ProductService(DatabaseContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<ProductDto>> Get() => 
      await _context.Products.Select(product => new ProductDto{}).ToListAsync();

    public async Task<ProductDto> GetById(int id)
    {
      var product = await _context.Products.FindAsync(id);
      if(product != null)
      {
        //Todo:
        return productDto;
      }
      return null;
    }

    public async Task<ProductDto> Add(ProductInsertDto productInsertDto)
    {
      var product = new Product()

      await _context.Products.AddAsync(product);
      await _context.SaveChangesAsync();

    }
    public async Task<ProductDto> Update(int id, ProductUpdateDto productUpdateDto)
    {
      var product = await _context.Products.FindAsync(id);
      if(product != null)
      {
        //Todo:
        return productDto;
      }
      return null;
    }
    public async Task<ProductDto> Delete(int id)
    {
      var product = await _context.Products.FindAsync(id);

      if(product != null)
      {
        //Todo:
        return productDto;
      }
      return null;
    }
  }

}