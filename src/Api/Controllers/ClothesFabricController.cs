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
            Guid convertedClothesId = Guid.Empty;
            Guid convertedFabricId = Guid.Empty;

            Guid.TryParse(clothesId, out convertedClothesId);
            Guid.TryParse(fabricId, out convertedFabricId);

            var request = new GetClothesFabricsQuery {
                ClothesId = convertedClothesId != Guid.Empty ? convertedClothesId : null,
                FabricId = convertedFabricId != Guid.Empty ? convertedFabricId : null
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
