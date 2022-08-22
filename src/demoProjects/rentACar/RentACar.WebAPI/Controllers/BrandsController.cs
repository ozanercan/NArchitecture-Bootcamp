using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.Brands.Commands.CreateBrand;
using RentACar.WebAPI.Controllers.Commons;

namespace RentACar.WebAPI.Controllers;

[Route("api/[controller]")]
public class BrandsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateBrandCommandRequest request)
    {
        var result = await Mediator.Send(request);

        return Created("", result);
    }
}
