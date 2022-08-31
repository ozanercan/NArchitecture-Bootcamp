using FluentValidation;
using RentACar.Application.Features.Brands.Commands.CreateBrand;

namespace RentACar.Application.Features.Brands.Validators;

public class CreateBrandCommandRequestValidator : AbstractValidator<CreateBrandCommandRequest>
{
    public CreateBrandCommandRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .MinimumLength(2);
    }
}
