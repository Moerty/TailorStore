using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TailorStore.Application.Option.Commands.AddOptionCommand;
using TailorStore.Application.Option.Queries.GetOptionsQuery;

namespace Api.Controllers {
    public class OptionController : ApiControllerBase {
        [HttpGet]
        public async Task<IActionResult> GetAsync(string typeId) {
            var request = new GetOptionsQuery();

            if(Guid.TryParse(typeId, out var convertedTypeId)) {
                request.TypeId = convertedTypeId;
            }

            return Ok(await Mediator.Send(request).ConfigureAwait(false));
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] AddOptionCommand command) {
            var result = await Mediator.Send(command).ConfigureAwait(false);

            if (result) return Ok();
            else return BadRequest();
        }
    }
}
