using FluentValidation;
using RentACar.Application.Features.Brands.Queries.GetBrandById;

namespace RentACar.Application.Features.Brands.Validators;

public class GetBrandByIdQueryRequestValidator : AbstractValidator<GetBrandByIdQueryRequest>
{
    public GetBrandByIdQueryRequestValidator()
    {
        RuleFor(_brand => _brand.Id)
            .NotNull()
            .GreaterThan(0);
    }
}
