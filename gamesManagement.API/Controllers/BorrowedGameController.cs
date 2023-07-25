using Azure.Core;
using gamesManagement.Application.DTOs;
using gamesManagement.Application.Services;
using gamesManagement.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace gamesManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BorrowedGameController : ControllerBase
    {
        private readonly IBorrowedGameService _barrowGameService;

        public BorrowedGameController(IBorrowedGameService barrowGameService)
        {
            _barrowGameService = barrowGameService;
        }


        [HttpPost("Post")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(BorrowedGameRequestDto request)
        {
            if (request is null)
                return Problem("The filled object is mandatory", statusCode: StatusCodes.Status400BadRequest);

            if (request.GameId <= 0)
                return Problem("The GameId field is mandatory", statusCode: StatusCodes.Status400BadRequest);

            if (request.FriendId <= 0)
                return Problem("The FriendId field is mandatory", statusCode: StatusCodes.Status400BadRequest);

            if (request.Id > 0)
                return Problem("The Id field cannot be filled in", statusCode: StatusCodes.Status400BadRequest);

            return Ok(await _barrowGameService.PostAsync(request));
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _barrowGameService.GetAsync());
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
                return Problem("The id field is mandatory", statusCode: StatusCodes.Status400BadRequest);

            return Ok(await _barrowGameService.Get(id));
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return Problem("The id field is mandatory", statusCode: StatusCodes.Status400BadRequest);

            return Ok(_barrowGameService.Delete(id));
        }

        [HttpPut("put")]
        public async Task<IActionResult> Update(BorrowedGameRequestDto request)
        {
            if (request is null)
                return Problem("The filled object is mandatory", statusCode: StatusCodes.Status400BadRequest);

            if (request.GameId <= 0)
                return Problem("The GameId field is mandatory", statusCode: StatusCodes.Status400BadRequest);

            if (request.FriendId <= 0)
                return Problem("The FriendId field is mandatory", statusCode: StatusCodes.Status400BadRequest);

            if (request.Id <= 0)
                return Problem("The Id field is mandatory", statusCode: StatusCodes.Status400BadRequest);

            return Ok(await _barrowGameService.UpdateAsync(request));
        }
    }
}
