using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.Brands.Commands.CreateBrand;
using RentACar.Application.Features.Brands.Queries.GetBrandById;
using RentACar.Application.Features.Brands.Queries.GetBrands;
using RentACar.WebAPI.Controllers.Commons;

namespace RentACar.WebAPI.Controllers;

[Route("api/[controller]")]
public class BrandsController : BaseController
{
    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(CreateBrandCommandRequest request)
    {
        var result = await Mediator.Send(request);

        return Created("", result);
    }

    [HttpGet("get-brands")]
    public async Task<IActionResult> GetBrandsAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await Mediator.Send(new GetBrandsQueryRequest() { Pagination = pageRequest });

        return Ok(result);
    }

    [HttpGet("get-brand-by-id")]
    public async Task<IActionResult> GetBrandByIdAsync([FromQuery] int id)
    {
        var result = await Mediator.Send(new GetBrandByIdQueryRequest() { Id = id });

        return Ok(result);
    }
}
