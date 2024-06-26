using DTOs;
using FluentValidation;

namespace Validators
{
  public class ProductInsertValidator: AbstractValidator<ProductInsertDto>
  {
    public ProductInsertValidator() {
      RuleFor(x => x.Name).NotEmpty().WithMessage("The name is required");
      RuleFor(x => x.Name).Length(2,10).WithMessage("The name must be 2 to 20 characters long");
      RuleFor(x => x.BrandId).NotNull().WithMessage("The brand is required");
      RuleFor(x => x.BrandId).GreaterThan(0).WithMessage("Error with brand sent value");
      RuleFor(x => x.Price).GreaterThan(0).WithMessage("The {PropertyName} must be greater than 0");
    }
  }
}