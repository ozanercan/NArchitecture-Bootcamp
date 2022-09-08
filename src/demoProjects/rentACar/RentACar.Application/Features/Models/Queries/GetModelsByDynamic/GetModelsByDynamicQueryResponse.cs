using Core.Persistence.Paging;
using RentACar.Application.Features.Models.Dtos;

namespace RentACar.Application.Features.Models.Queries.GetModelsByDynamic;

public class GetModelsByDynamicQueryResponse : BasePageableModel
{
    public ICollection<ModelListDto> Items { get; set; }
}
