using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;

namespace RentACar.Application.Features.Models.Queries.GetModelsByDynamic;

public class GetModelsByDynamicQueryRequest : IRequest<GetModelsByDynamicQueryResponse>
{
    public Dynamic Dynamic { get; set; }
    public PageRequest Pagination { get; set; }
}