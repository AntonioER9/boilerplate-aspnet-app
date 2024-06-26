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
        private DatabaseContext _context;
        private IValidator<ProductInsertDto> _productInsertValidator;
        private IValidator<ProductUpdateDto> _productUpdateValidator;
        public ProductController(
            DatabaseContext context,
            IValidator<ProductInsertDto> productInsertValidator,
            IValidator<ProductUpdateDto> productUpdateValidator,
        )
        {
            _context = context;
            _productInsertValidator = productInsertValidator;
            _productUpdateValidator = productUpdateValidator;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDto>> Get() {
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(int id) {

        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> Add(ProductInsertDto productInsertDto) 
        {
            var validationResult = await _productInsertValidator.ValidateAsync(productInsertDto);

            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Erros);
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> Update(int id, ProductUpdateDto productUpdateDto) {

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) {

        }
    }
}