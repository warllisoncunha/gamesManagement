using gamesManagement.Application.DTOs;
using gamesManagement.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace gamesManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FriendController : ControllerBase
    {
        private readonly IFriendService _friendService;

        public FriendController(IFriendService friendService)
        {
            _friendService = friendService;
        }

        [HttpPost("Post")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(FriendRequestDto request)
        {
            if (request is null)
                return Problem("The filled object is mandatory", statusCode: StatusCodes.Status400BadRequest);

            if (string.IsNullOrEmpty(request.Name))
                return Problem("The name field is mandatory", statusCode: StatusCodes.Status400BadRequest);

            if (request.Id > 0)
                return Problem("The Id field cannot be filled in", statusCode: StatusCodes.Status400BadRequest);

            return Ok(await _friendService.PostAsync(request));
        }

        [HttpGet("Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _friendService.GetAsync());
        }

        [HttpGet("get/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
                return Problem("The id field is mandatory", statusCode: StatusCodes.Status400BadRequest);

            return Ok(await _friendService.Get(id));
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return Problem("The id field is mandatory", statusCode: StatusCodes.Status400BadRequest);

            return Ok(_friendService.Delete(id));
        }

        [HttpPut("put")]
        public async Task<IActionResult> Update(FriendRequestDto request)
        {
            if (request is null)
                return Problem("The filled object is mandatory", statusCode: StatusCodes.Status400BadRequest);

            if (string.IsNullOrEmpty(request.Name))
                return Problem("The name field is mandatory", statusCode: StatusCodes.Status400BadRequest);

            if (request.Id <= 0)
                return Problem("The Id field is mandatory", statusCode: StatusCodes.Status400BadRequest);

            return Ok(await _friendService.UpdateAsync(request));
        }
    }
}
