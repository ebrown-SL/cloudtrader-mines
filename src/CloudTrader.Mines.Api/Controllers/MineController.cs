using CloudTrader.Mines.Models.API;
using CloudTrader.Mines.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;
using CloudTrader.Mines.Models.Service;

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
        [SwaggerOperation(Summary = "Get all mines", Description = "Returns an empty list if no mines exist")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(System.Collections.Generic.List<Mine>))]
        public async Task<IActionResult> GetMines()
        {
            var mines = await _mineService.GetMines();

            return Ok(mines);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Finds a mine by ID")]
        [SwaggerResponse(StatusCodes.Status200OK, "Mine found", typeof(Mine))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Mine was not found")]
        public async Task<IActionResult> GetMine([FromRoute, SwaggerParameter("The mine id")]int id)
        {
            var mine = await _mineService.GetMine(id);

            return Ok(mine);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Creates a new mine")]
        [SwaggerResponse(StatusCodes.Status201Created, "Mine created", typeof(Mine))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "The mine data was invalid")]
        public async Task<IActionResult> CreateMine([FromBody, SwaggerRequestBody("The mine creation payload")] MineCreationModel creationModel)
        {
            var mine = await _mineService.CreateMine(creationModel.Name, creationModel.Coordinates);

            return Created($"api/mine/{mine.Id}", mine);
        }
    }
}
