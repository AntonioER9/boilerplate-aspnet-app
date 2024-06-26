using AutoMapper;
using DTOs;
using Models;
using Repository;


namespace Services
{
  public class ProductService : ICommonService<ProductDto, ProductInsertDto, ProductUpdateDto>
  {
    private IRepository<Product> _productRepository;
    private IMapper _mapper;
    public List<string> Errors { get; }
    public ProductService(
      IRepository<Product> productRepository,
      IMapper mapper
    )
    {
      _productRepository = productRepository;
      _mapper = mapper;
      Errors = new List<string>();
    }

    public async Task<IEnumerable<ProductDto>> Get() {
      var products = await _productRepository.Get();
      return products.Select(product => _mapper.Map<ProductDto>(product));
    }

    public async Task<ProductDto> GetById(int id) {

      var product = await _productRepository.GetById(id);

      if(product != null) {
        var productDto = _mapper.Map<ProductDto>(product);
        return productDto;
      }

      return null;
    }

    public async Task<ProductDto> Add(ProductInsertDto productInsertDto) {
      var product = _mapper.Map<Product>(productInsertDto);
      
      await _productRepository.Add(product);
      await _productRepository.Save();

      var productDto = _mapper.Map<ProductDto>(product);

      return productDto;
    }

    public async Task<ProductDto> Update(int id, ProductUpdateDto productUpdateDto) {
      var product = await _productRepository.GetById(id);

      if(product != null) {
        product = _mapper.Map<productUpdateDto, Product>(productUpdateDto, product);
        _productRepository.Update(product);
        await _productRepository.Save();

        var productDto = _mapper.Map<productDto>(product);
        return productDto;
      }

      return null;
    }
    public async Task<ProductDto> Delete(int id) {
      var product = await _productRepository.GetById(id);

      if(product != null) {
        var productDto = _mapper.Map<productDto>(product);
        
        _productRepository.Delete(product);
        await _productRepository.Save();
        
        return productDto;
      }

      return null;
    }

    public bool Validate(ProductInsertDto productInsertDto) {

      if (_productRepository.Search(product => product.Name == productInsertDto.Name).Count() > 0) {
        Errors.Add("The product name already exists");
        return false;
      }
      return true;

    }
    public bool Validate(ProductUpdateDto productUpdateDto) {

      if (_productRepository.Search(product => product.Name == productUpdateDto.Name 
          && productUpdateDto.Id != product.ProductID).Count() > 0) {
        Errors.Add("The product name already exists");
        return false;
      }
      return true;
    }

  }

}