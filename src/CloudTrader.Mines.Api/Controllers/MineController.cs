using CloudTrader.Mines.Models.API;
using CloudTrader.Mines.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CloudTrader.Mines.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MineController : ControllerBase
    {
        private readonly IMineService _mineService;

        public MineController(IMineService mineService)
        {
            _mineService = mineService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMines()
        {
            var mines = await _mineService.GetMines();

            return Ok(mines);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMine(int id)
        {
            var mine = await _mineService.GetMine(id);

            return Ok(mine);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMine(MineCreationModel creationModel)
        {
            var mine = await _mineService.CreateMine(creationModel.Coordinates);

            return Ok(mine);
        }
    }
}
