using Core.Persistence.Paging;
using RentACar.Application.Features.Brands.Dtos;

namespace RentACar.Application.Features.Brands.Queries.GetBrands;

public class GetBrandsQueryResponse : BasePageableModel
{
    public ICollection<BrandDto> Items { get; set; }
}