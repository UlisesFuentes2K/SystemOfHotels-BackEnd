using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SOH.CORE.Features.User;
using SOH.MAIN.Models.Users;
using System.IdentityModel.Tokens.Jwt;

namespace SOH.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly UserManager<SR_Users> _userManager;
        public UserController(IMediator mediator, UserManager<SR_Users> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }

        // Obtener datos de un usuario por ID
        [Authorize]
        [HttpGet("{id}")]
        public async Task<SR_Users> Get([FromRoute] string id)
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
            var result = await _mediator.Send(common);

            return Ok(new
            {
                response = result
            });
        }

        // Actualizar los datos de un usuario
        [Authorize]
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
        [Authorize]
        [HttpPut("active")]
        public async Task<bool> Active([FromBody] IsActiveUserCommon common)
        {
            return await _mediator.Send(common);
        }

        [Authorize]
        [HttpPut("logout/{userId}")]
        public async Task<IActionResult> Logout(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return Unauthorized("Usuario no encontrado");
            }

            user.SecurityStamp = Guid.NewGuid().ToString();
            await _userManager.UpdateAsync(user);

            return Ok(new { message = "Sesión cerrada correctamente" });
        }
    }
}
