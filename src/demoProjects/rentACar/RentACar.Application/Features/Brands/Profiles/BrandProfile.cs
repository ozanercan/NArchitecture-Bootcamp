using AutoMapper;
using Core.Persistence.Paging;
using RentACar.Application.Features.Brands.Commands.CreateBrand;
using RentACar.Application.Features.Brands.Dtos;
using RentACar.Application.Features.Brands.Queries.GetBrands;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Brands.Profiles;
public class BrandProfile : Profile
{
    public BrandProfile()
    {
        CreateMap<CreateBrandCommandRequest, Brand>();

        CreateMap<Brand, CreatedBrandDto>();

        CreateMap<Brand, BrandDto>();

        CreateMap<IPaginate<Brand>, GetBrandsQueryResponse>();
    }
}
