using AutoMapper;
using MediatR;
using RentACar.Application.Features.Brands.Dtos;
using RentACar.Application.Features.Brands.Rules;
using RentACar.Application.Services.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Brands.Queries.GetBrandById;

public class GetBrandByIdQueryRequestHandler : IRequestHandler<GetBrandByIdQueryRequest, BrandDto>
{
    private readonly IBrandRepository _repository;
    private readonly IMapper _mapper;
    private readonly BrandBusinessRules _brandBusinessRules;
    public GetBrandByIdQueryRequestHandler(IBrandRepository repository, IMapper mapper, BrandBusinessRules brandBusinessRules)
    {
        _repository = repository;
        _mapper = mapper;
        _brandBusinessRules = brandBusinessRules;
    }

    public async Task<BrandDto> Handle(GetBrandByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var brand = await _repository.GetAsync(_brand => _brand.Id.Equals(request.Id));

        _brandBusinessRules.BrandShouldExistWhenCalledGetByIdMethod(brand);

        return _mapper.Map<Brand, BrandDto>(brand);
    }
}
