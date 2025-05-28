using MediatR;
using Microsoft.AspNetCore.Mvc;
using SOH.CORE.Features.User;
using SOH.MAIN.Models.Users;

namespace SOH.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Obtener datos de un usuario por ID
        [HttpGet("{id}")]
        public async Task<SR_Users> Get([FromRoute]string id)
        {
            return await _mediator.Send(new GetOneUserQuery { Id = id });
        }

        // Guardar nuevo usuario
        [HttpPost]
        public async Task<SR_Users> Post([FromBody] AddUserCommon common)
        {
            return await _mediator.Send(common);
        }

        // Actualizar los datos de un usuario
        [HttpPut]
        public async Task<SR_Users> Put([FromBody] UpdateUserCommon common)
        {
            return await _mediator.Send(common);
        }

        // Activar o desactivar un usuario
        [HttpPost("active")]
        public void Delete(int id)
        {
        }
    }
}
