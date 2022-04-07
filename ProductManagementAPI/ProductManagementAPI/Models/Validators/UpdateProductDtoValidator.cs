using FluentValidation;
using ProductManagementAPI.Entities;

namespace ProductManagementAPI.Models.Validators
{
    public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductDtoValidator(ProductManagementDbContext dbContext)
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Description)
                .MaximumLength(200);
        }

    }
}
