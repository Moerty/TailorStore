using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TailorStore.Application.Clothes.Commands.AddClothesCommand;
using TailorStore.Application.Clothes.Queries.GetClothesQuery;

namespace Api.Controllers {
    public class ClothesController : ApiControllerBase {
        [HttpGet]
        public async Task<IActionResult> GetAsync() {
            return Ok(await Mediator.Send(new GetClothesQuery()).ConfigureAwait(false));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AddClothesCommand command) {
            var result = await Mediator
                .Send(command)
                .ConfigureAwait(false);

            if (result) return Ok();
            else return BadRequest();
        }
    }
}
