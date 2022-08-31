using AutoMapper;
using Core.Persistence.Paging;
using MediatR;
using RentACar.Application.Services.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Brands.Queries.GetBrands;

public class GetBrandsQueryRequestHandler : IRequestHandler<GetBrandsQueryRequest, GetBrandsQueryResponse>
{
    private readonly IBrandRepository _repository;
    private readonly IMapper _mapper;

    public GetBrandsQueryRequestHandler(IBrandRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetBrandsQueryResponse> Handle(GetBrandsQueryRequest request, CancellationToken cancellationToken)
    {
        var brands = await _repository.GetListAsync(index: request.Pagination.Page, size: request.Pagination.PageSize);

        return _mapper.Map<IPaginate<Brand>, GetBrandsQueryResponse>(brands);
    }
}
