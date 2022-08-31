using MediatR;
using RentACar.Application.Features.Brands.Dtos;

namespace RentACar.Application.Features.Brands.Queries.GetBrandById;

public class GetBrandByIdQueryRequest : IRequest<BrandDto>
{
    public int Id { get; set; }
}
