using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TailorStore.Application.ClothesOption.Commands.AddClothesOptionCommand;
using TailorStore.Application.ClothesOption.Queries.GetClothesOptionsQuery;

namespace Api.Controllers
{
    public class ClothesOptionController : ApiControllerBase {
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] string clothesId, [FromQuery] string optionId) {
            var request = new GetClothesOptionsQuery {
                ClothesId = Guid.TryParse(clothesId, out Guid convertedClothesId) ? convertedClothesId : null,
                OptionID = Guid.TryParse(optionId, out Guid convertedOptionId) ? convertedOptionId : null
            };

            return Ok(await Mediator
                .Send(request)
                .ConfigureAwait(false));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AddClothesOptionCommand command) {
            var result = await Mediator.Send(command).ConfigureAwait(false);

            if (result) return Ok();
            else return BadRequest();
        }
    }
}
