using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;

namespace RentACar.Application.Features.Models.Queries.GetModels;

public class GetModelsQueryRequest : IRequest<GetModelsQueryResponse>
{
    public PageRequest Pagination { get; set; }
}
