using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SOH.CORE.Features.TypeDocument;
using SOH.MAIN.Models.Customer;

namespace SOH.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TypeDocumentController : ControllerBase
    {
        private readonly IMediator _mediator;

        [Authorize]
        [HttpGet]
        public async Task<List<SR_TypeDocument>> Get([FromQuery] GetTypeDocumentQuery query)
        {
            return await _mediator.Send(query);
        }

        // POST api/<TypeDocumentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TypeDocumentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TypeDocumentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
