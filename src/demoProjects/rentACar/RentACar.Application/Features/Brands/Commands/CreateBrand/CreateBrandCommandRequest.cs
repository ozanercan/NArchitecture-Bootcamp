using MediatR;
using RentACar.Application.Features.Brands.Dtos;

namespace RentACar.Application.Features.Brands.Commands.CreateBrand;

public class CreateBrandCommandRequest : IRequest<CreatedBrandDto>
{
    public string Name { get; set; } = string.Empty;
}
