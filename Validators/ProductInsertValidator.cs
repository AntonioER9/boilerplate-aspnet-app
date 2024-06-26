using DTOs;
using FluentValidation;

namespace Validators
{
  public class ProductInsertValidator: AbstractValidator<ProductInsertDto>
  {
    public ProductInsertValidator() {
      RuleFor(x => x.Name).NotEmpty();
    }
  }
}