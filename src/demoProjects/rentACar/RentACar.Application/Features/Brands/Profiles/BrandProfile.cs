using AutoMapper;
using RentACar.Application.Features.Brands.Commands.CreateBrand;
using RentACar.Application.Features.Brands.Dtos;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Brands.Profiles;
public class BrandProfile : Profile
{
    public BrandProfile()
    {
        CreateMap<CreateBrandCommandRequest, Brand>();

        CreateMap<Brand, CreatedBrandDto>();
    }
}
