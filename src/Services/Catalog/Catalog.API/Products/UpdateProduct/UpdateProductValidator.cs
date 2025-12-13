using FluentValidation;

namespace Catalog.API.Products.UpdateProduct
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Product id is required.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(200).WithMessage("Product name cannot exceed 200 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Product description is required.")
                .MaximumLength(1000).WithMessage("Description cannot exceed 1000 characters.");

            RuleFor(x => x.ImageFile)
                .NotEmpty().WithMessage("Image file is required.")
                .MaximumLength(300).WithMessage("Image file path is too long.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero.");

            RuleFor(x => x.Category)
                .NotNull().WithMessage("Category list is required.")
                .Must(c => c.Count > 0).WithMessage("At least one category is required.");

            RuleForEach(x => x.Category)
                .NotEmpty().WithMessage("Category name cannot be empty.")
                .MaximumLength(100).WithMessage("Category name cannot exceed 100 characters.");
        }
    }
}