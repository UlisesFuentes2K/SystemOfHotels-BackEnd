using MediatR;
using Microsoft.AspNetCore.Mvc;
using SOH.CORE.Dto;
using SOH.CORE.Features.RegisterGet;

namespace SOH.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RegisterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<RegisterData> Get([FromQuery] GetRegisterQuery query)
        {
            return await _mediator.Send(query);
        }
    }
}
