using AutoMapper;
using Core.Persistence.Paging;
using RentACar.Application.Features.Models.Dtos;
using RentACar.Application.Features.Models.Queries.GetModels;
using RentACar.Application.Features.Models.Queries.GetModelsByDynamic;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Models.Profiles;
public class ModelProfiles : Profile
{
    public ModelProfiles()
    {
        CreateMap<Model, ModelListDto>()
            .ForMember(x => x.BrandName, mopt => mopt.MapFrom(v => v.Brand.Name));

        CreateMap<IPaginate<Model>, GetModelsQueryResponse>();
        CreateMap<IPaginate<Model>, GetModelsByDynamicQueryResponse>();
    }
}
