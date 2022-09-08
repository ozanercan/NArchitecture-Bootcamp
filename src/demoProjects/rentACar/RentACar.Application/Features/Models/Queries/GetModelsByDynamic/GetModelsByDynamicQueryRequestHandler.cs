using AutoMapper;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RentACar.Application.Services.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Models.Queries.GetModelsByDynamic;

public class GetModelsByDynamicQueryRequestHandler : IRequestHandler<GetModelsByDynamicQueryRequest, GetModelsByDynamicQueryResponse>
{
    private readonly IModelRepository _modelRepository;
    private readonly IMapper _mapper;

    public GetModelsByDynamicQueryRequestHandler(IModelRepository modelRepository, IMapper mapper)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;
    }

    public async Task<GetModelsByDynamicQueryResponse> Handle(GetModelsByDynamicQueryRequest request, CancellationToken cancellationToken)
    {
        var paginateModels = await _modelRepository.GetListByDynamicAsync(dynamic: request.Dynamic, include: _model => _model.Include(x => x.Brand), index: request.Pagination.Page, size: request.Pagination.PageSize);

        return _mapper.Map<IPaginate<Model>, GetModelsByDynamicQueryResponse>(paginateModels);
    }
}
