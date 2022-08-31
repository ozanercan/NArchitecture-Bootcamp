using Core.CrossCuttingConcerns.Exceptions;
using RentACar.Application.Services.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Brands.Rules;
public class BrandBusinessRules
{
    private readonly IBrandRepository _brandRepository;

    public BrandBusinessRules(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task BrandNameCanNotDuplicateWhenInserted(string name)
    {
        var brand = await _brandRepository.GetAsync(_brand => _brand.Name.Equals(name));
        if (brand is null) return;

        throw new BusinessException("Brand name is already exist.");
    }

    public void BrandShouldExistWhenCalledGetByIdMethod(Brand brand)
    {
        if (brand is null)
            throw new BusinessException("Brand not found.");
    }
}
