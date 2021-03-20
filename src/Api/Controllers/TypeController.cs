using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TailorStore.Application.Type.Commands.AddTypeCommand;
using TailorStore.Application.Type.Queries.GetTypesQuery;

namespace Api.Controllers
{
    public class TypeController : ApiControllerBase {
        [HttpGet]
        public async Task<IActionResult> GetAsync() {
            return Ok(await Mediator.Send(new GetTypesQuery()).ConfigureAwait(false));
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] AddTypeCommand command) {
            var result = await Mediator.Send(command).ConfigureAwait(false);

            if (result) return Ok();
            else return BadRequest();
        }
    }
}
