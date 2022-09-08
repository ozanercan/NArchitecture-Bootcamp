using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.Models.Queries.GetModels;
using RentACar.Application.Features.Models.Queries.GetModelsByDynamic;
using RentACar.WebAPI.Controllers.Commons;

namespace RentACar.WebAPI.Controllers;

[Route("api/[controller]")]
public class ModelsController : BaseController
{
    //[HttpPost("create")]
    //public async Task<IActionResult> CreateAsync(CreateBrandCommandRequest request)
    //{
    //    var result = await Mediator.Send(request);

    //    return Created("", result);
    //}

    [HttpGet("get-models")]
    public async Task<IActionResult> GetModelsAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await Mediator.Send(new GetModelsQueryRequest() { Pagination = pageRequest });

        return Ok(result);
    }

    [HttpPost("get-models-by-dynamic")]
    public async Task<IActionResult> GetModelsAsync([FromQuery] PageRequest pagination, [FromBody] Dynamic dynamic)
    {
        var result = await Mediator.Send(new GetModelsByDynamicQueryRequest() { Pagination = pagination, Dynamic = dynamic });

        return Ok(result);
    }

    //[HttpGet("get-brand-by-id")]
    //public async Task<IActionResult> GetBrandByIdAsync([FromQuery] int id)
    //{
    //    var result = await Mediator.Send(new GetBrandByIdQueryRequest() { Id = id });

    //    return Ok(result);
    //}
}
