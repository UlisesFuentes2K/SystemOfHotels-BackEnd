using MediatR;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
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

        // validar usuario
        [HttpPost("validation")]
        public async Task<IActionResult> PostValidate([FromBody] GetVerificationUser common)
        {
            var result =  await _mediator.Send(common);

            if (result.token == null) return Unauthorized();

            return Ok(new
            {
                token = result.token,
                userId = result.Id,
                idTypePerson = result.idTypePerson,
                rol = result.Rol,
                idPerson = result.idPerson
            });
        }

        // Actualizar los datos de un usuario
        //[Authorize]
        [HttpPut]
        public async Task<SR_Users> Put([FromBody] UpdateUserCommon common)
        {
            return await _mediator.Send(common);
        }

        // Actualizar la contraseña de un usuario
        [HttpPut("change/password")]
        public async Task<bool> PutPass([FromBody] UpdatePasswordCommon common)
        {
            return await _mediator.Send(common);
        }

        // Activar o desactivar un usuario
        //[Authorize]
        [HttpPost("active")]
        public async Task<bool> Active([FromBody] IsActiveUserCommon common)
        {
            return await _mediator.Send(common);
        }
    }
}
