using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneOf;
using SOH.CORE.Features.Person;
using SOH.MAIN.Models.Customer;

namespace SOH.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Mostrar todas las personas registradas en el sistema
        [Authorize]
        [HttpGet]
        public async Task<List<SR_Person>> GetAll([FromQuery] GetAllPersonQuery query)
        {
            return await _mediator.Send(query);
        }

        // Mostrar los datos de una persona registrada en el sistema
        [Authorize]
        [HttpGet("{id}")]
        public async Task<SR_Person> GetOne([FromRoute] int id)
        {
            return await _mediator.Send(new GetOnePersonQuery { idPerson = id});
        }

        //Agregar una nueva persona
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddPersonCommon common)
        {
            var resultado = await _mediator.Send(common);

            return resultado.Match<IActionResult>(
                persona => CreatedAtAction(nameof(Post), new { id = persona.idPerson }, persona),  
                error => BadRequest(error)  
            );
        }

        //Actualizar los datos de una persona
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdatePersonCommon common)
        {
            var resultado = await _mediator.Send(common);

            return resultado.Match<IActionResult>(
                persona => CreatedAtAction(nameof(Post), new { id = persona.idPerson }, persona),
                error => BadRequest(error)
            );
        }
    }
}
