using Core.Persistence.Paging;
using RentACar.Application.Features.Models.Dtos;

namespace RentACar.Application.Features.Models.Queries.GetModels;

public class GetModelsQueryResponse : BasePageableModel
{
    public ICollection<ModelListDto> Items { get; set; }
}
