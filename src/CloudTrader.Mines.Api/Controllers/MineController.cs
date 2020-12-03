using CloudTrader.Mines.Models.API;
using CloudTrader.Mines.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;
using CloudTrader.Mines.Models.Service;
using System;
using System.Collections.Generic;

namespace CloudTrader.Mines.Api.Controllers
{
    [Route("api/mine")]
    [ApiController]
    public class MineController : ControllerBase
    {
        private readonly IMineService _mineService;

        public MineController(IMineService mineService)
        {
            _mineService = mineService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all mines", Description = "Returns an object containing an array of mines")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(GetAllMinesResponseModel))]
        public async Task<IActionResult> GetMines()
        {
            var mines = new GetAllMinesResponseModel(await _mineService.GetMines());

            return Ok(mines);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new mine")]
        [SwaggerResponse(StatusCodes.Status201Created, "Mine created", typeof(Mine))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "The mine data was invalid")]
        public async Task<IActionResult> CreateMine([FromBody, SwaggerRequestBody("The mine creation payload")] MineCreationModel creationModel)
        {
            var mine = await _mineService.CreateMine(creationModel.Name, creationModel.Coordinates);

            return Created($"api/mine/{mine.Id}", mine);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Find a mine by ID")]
        [SwaggerResponse(StatusCodes.Status200OK, "Mine found", typeof(Mine))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Mine was not found")]
        public async Task<IActionResult> GetMine([FromRoute, SwaggerParameter("The mine ID")] Guid id)
        {
            var mine = await _mineService.GetMine(id);

            return Ok(mine);
        }

        [HttpPatch("{id}")]
        [SwaggerOperation(Summary = "Update a mine")]
        [SwaggerResponse(StatusCodes.Status200OK, "Mine updated", typeof(Mine))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Mine was not found")]
        public async Task<IActionResult> UpdateMine([FromRoute, SwaggerParameter("The mine ID")] Guid id, [FromBody, SwaggerRequestBody("The mine update payload")] MineUpdateModel updateModel)
        {
            var mine = await _mineService.UpdateMine(id, updateModel);

            return Ok(mine);
        }
    }
}
