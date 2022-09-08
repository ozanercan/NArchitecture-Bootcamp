using AutoMapper;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RentACar.Application.Features.Models.Dtos;
using RentACar.Application.Services.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Models.Queries.GetModels;

public class GetModelsQueryRequestHandler : IRequestHandler<GetModelsQueryRequest, GetModelsQueryResponse>
{
    private readonly IModelRepository _readRepository;
    private readonly IMapper _mapper;

    public GetModelsQueryRequestHandler(IModelRepository readRepository, IMapper mapper)
    {
        _readRepository = readRepository;
        _mapper = mapper;
    }

    public async Task<GetModelsQueryResponse> Handle(GetModelsQueryRequest request, CancellationToken cancellationToken)
    {
        var paginateModels = await _readRepository.GetListAsync(include: _model => _model.Include(x => x.Brand), index: request.Pagination.Page, size: request.Pagination.PageSize);

        return _mapper.Map<IPaginate<Model>, GetModelsQueryResponse>(paginateModels);
    }
}
