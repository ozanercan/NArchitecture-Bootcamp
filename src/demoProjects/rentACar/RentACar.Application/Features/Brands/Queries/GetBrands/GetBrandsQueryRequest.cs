using Core.Application.Requests;
using MediatR;

namespace RentACar.Application.Features.Brands.Queries.GetBrands;

public class GetBrandsQueryRequest : IRequest<GetBrandsQueryResponse>
{
    public PageRequest Pagination { get; set; }
}
