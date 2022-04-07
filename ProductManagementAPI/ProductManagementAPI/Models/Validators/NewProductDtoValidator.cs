using FluentValidation;
using ProductManagementAPI.Entities;

namespace ProductManagementAPI.Models.Validators
{
    public class NewProductDtoValidator : AbstractValidator<NewProductDto>
    {
        public NewProductDtoValidator(ProductManagementDbContext dbContext)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Price)
                .NotEmpty();

            RuleFor(x => x.Description)
                .MaximumLength(200);
        }
    }
}
