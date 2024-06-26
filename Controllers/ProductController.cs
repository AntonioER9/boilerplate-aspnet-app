using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.EntityFrameworkCore;
using DTOs;
using Models;
using FluentValidation;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {

        private IValidator<ProductInsertDto> _productInsertValidator;
        private IValidator<ProductUpdateDto> _productUpdateValidator;
        private ICommonService<ProductDto, ProductInsertDto, ProductUpdateDto> _productService;
        public ProductController(
            IValidator<ProductInsertDto> productInsertValidator,
            IValidator<ProductUpdateDto> productUpdateValidator,
            [FromKeyedServices("productService")] ICommonService<ProductDto, ProductInsertDto, ProductUpdateDto> productService,
        )
        {
            _productInsertValidator = productInsertValidator;
            _productUpdateValidator = productUpdateValidator;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDto>> Get() {
            await _productService.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(int id) {
            var productDto = await _productService.GetById(id);

            return productDto == null ? NotFound() : Ok(productDto);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> Add(ProductInsertDto productInsertDto) 
        {
            var validationResult = await _productInsertValidator.ValidateAsync(productInsertDto);

            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Erros);
            }

            var productDto = await _productService.Add(productInsertDto);
            return CreatedAtAction(nameof(GetById), new { id = productDto.Id }, productDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> Update(int id, ProductUpdateDto productUpdateDto) {
            var validationResult = await _productUpdateValidator.ValidateAsync(productUpdateDto);
            
            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Erros);
            }

            var productDto = await _productService.Update(id, productDto);

            return productDto == null ? NotFound() : Ok(productDto);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductDto>> Delete(int id) 
        {
            var productDto = await _productService.Delete(id);
            return productDto == null ? NotFound() : Ok(productDto);
        }
    }
}