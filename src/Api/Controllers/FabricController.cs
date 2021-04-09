using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TailorStore.Application.Fabric.Commands.AddFabricCommand;
using TailorStore.Application.Fabric.Commands.DeleteFabricCommand;
using TailorStore.Application.Fabric.Queries.GetFabricsQuery;

namespace Api.Controllers
{
    public class FabricController : ApiControllerBase {
        [HttpGet]
        public async Task<IActionResult> GetAsync() {
            return Ok(await Mediator.Send(new GetFabricsQuery()).ConfigureAwait(false));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AddFabricCommand command) {
            var result = await Mediator.Send(command).ConfigureAwait(false);

            if (result) return Ok();
            else return Problem();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteFabricCommand command) {
            var result = await Mediator
                .Send(command)
                .ConfigureAwait(false);

            if (result) return Ok();
            else return Problem();
        }
    }
}
