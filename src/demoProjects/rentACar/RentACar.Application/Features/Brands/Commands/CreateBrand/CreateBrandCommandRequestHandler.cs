using AutoMapper;
using MediatR;
using RentACar.Application.Features.Brands.Dtos;
using RentACar.Application.Features.Brands.Rules;
using RentACar.Application.Services.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Brands.Commands.CreateBrand;

public class CreateBrandCommandRequestHandler : IRequestHandler<CreateBrandCommandRequest, CreatedBrandDto>
{
    private readonly IBrandRepository _repository;
    private readonly IMapper _mapper;
    private readonly BrandBusinessRules _brandBusinessRules;

    public CreateBrandCommandRequestHandler(IBrandRepository repository, IMapper mapper, BrandBusinessRules brandBusinessRules)
    {
        _repository = repository;
        _mapper = mapper;
        _brandBusinessRules = brandBusinessRules;
    }

    public async Task<CreatedBrandDto> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
    {
        await _brandBusinessRules.BrandNameCanNotDuplicateWhenInserted(request.Name);

        var brandToCreate = _mapper.Map<CreateBrandCommandRequest, Brand>(request);

        var createdEntity = await _repository.AddAsync(brandToCreate);

        return _mapper.Map<Brand, CreatedBrandDto>(createdEntity);
    }
}
