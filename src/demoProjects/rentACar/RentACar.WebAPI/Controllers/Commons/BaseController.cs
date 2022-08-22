using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RentACar.WebAPI.Controllers.Commons;

[ApiController]
public class BaseController : ControllerBase
{
    protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    private IMediator? _mediator;
}
