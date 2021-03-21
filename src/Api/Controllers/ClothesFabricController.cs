using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TailorStore.Application.ClothesFabric.Commands.AddClothesFabricCommand;
using TailorStore.Application.ClothesFabric.Queries.GetClothesFabricsQuery;

namespace Api.Controllers
{
    public class ClothesFabricController : ApiControllerBase {
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] string clothesId, [FromQuery] string fabricId) {
            var request = new GetClothesFabricsQuery {
                ClothesId = Guid.TryParse(clothesId, out var convertedClothesId) ? convertedClothesId : null,
                FabricId = Guid.TryParse(fabricId, out var convertedFabricId) ? convertedFabricId : null
            };

            return Ok(await Mediator
                .Send(request)
                .ConfigureAwait(false));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AddClothesFabricCommand command) {
            var result = await Mediator.Send(command).ConfigureAwait(false);

            if (result) return Ok();
            else return BadRequest();
        }
    }
}
