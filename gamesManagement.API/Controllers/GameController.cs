using Azure.Core;
using gamesManagement.Application.DTOs;
using gamesManagement.Application.Services;
using gamesManagement.Application.Services.Interfaces;
using gamesManagement.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gamesManagement.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost("Post")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(GameRequestDto request)
        {
            if (request is null)
                return Problem("The filled object is mandatory", statusCode: StatusCodes.Status400BadRequest);

            if (string.IsNullOrEmpty(request.Name))
                return Problem("The name field is mandatory", statusCode: StatusCodes.Status400BadRequest);

            if (request.Id > 0)
                return Problem("The Id field cannot be filled in", statusCode: StatusCodes.Status400BadRequest);

            return Ok(await _gameService.PostAsync(request));
        }

        [HttpPost("Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _gameService.GetAsync());
        }

        [HttpGet("get/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            if (id <=0)
                return Problem("The id field is mandatory", statusCode: StatusCodes.Status400BadRequest);

            return Ok(await _gameService.Get(id));
        }

        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return Problem("The id field is mandatory", statusCode: StatusCodes.Status400BadRequest);

            return Ok(_gameService.Delete(id));
        }

        [HttpPut("put")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(GameRequestDto request)
        {
            if (request is null)
                return Problem("The filled object is mandatory", statusCode: StatusCodes.Status400BadRequest);

            if (string.IsNullOrEmpty(request.Name))
                return Problem("The name field is mandatory", statusCode: StatusCodes.Status400BadRequest);

            if (request.Id <= 0)
                return Problem("The Id field is mandatory", statusCode: StatusCodes.Status400BadRequest);

            return Ok(await _gameService.UpdateAsync(request));
        }
    }
}
