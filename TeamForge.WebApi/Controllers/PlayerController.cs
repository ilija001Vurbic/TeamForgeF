using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamForge.Model;
using TeamForge.Service;
using TeamForge.Service.Common;

namespace TeamForge.WebApi.Controllers
{
    [ApiController]
    [Route("api/players")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService playerService;

        public PlayerController(IPlayerService playerService)
        {
            this.playerService = playerService;
        }

        // GET: api/players/{id}
        [HttpGet("{id}")]
        public IActionResult GetPlayer(Guid id)
        {
            var player = playerService.GetPlayerById(id);
            if (player == null)
            {
                return NotFound(); // Return 404 if player not found
            }
            return Ok(player);
        }
        /*[HttpGet]
        public IActionResult GetPlayers([FromQuery] string sortBy = "Name", [FromQuery] bool isDescending = false, [FromQuery] string filterBy = "", [FromQuery] string filterValue = "", [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return BadRequest("Page number and page size must be greater than zero.");
            }

            var players = playerService.GetPlayers(sortBy, isDescending, filterBy, filterValue, pageNumber, pageSize, out int totalRecords);
            var response = new
            {
                TotalRecords = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize,
                Players = players
            };
            return Ok(response);
        }*/


        // GET: api/players
        [HttpGet]
        public IActionResult GetAllPlayers()
        {
            var players = playerService.GetAllPlayers();
            return Ok(players);
        }

        // POST: api/players
        [HttpPost]
        public IActionResult AddPlayer([FromBody] PlayerDto playerDto)
        {
            if (playerDto == null)
            {
                return BadRequest("Player data is missing"); // Return 400 if request body is empty
            }

            // Map PlayerDto to Player entity if needed
            var player = new Player
            {
                Id = Guid.NewGuid(),
                Name = playerDto.Name,
                Height = playerDto.Height,
                Weight = playerDto.Weight,
                Age = playerDto.Age,
                Blocking = playerDto.Blocking,
                Attacking = playerDto.Attacking,
                Serving = playerDto.Serving,
                Passing = playerDto.Passing,
                Setting = playerDto.Setting
            };

            playerService.AddPlayer(player);

            return CreatedAtAction(nameof(GetPlayer), new { id = player.Id }, player);
        }

        // PUT: api/players/{id}
        [HttpPut("{id}")]
        public IActionResult UpdatePlayer(Guid id, [FromBody] PlayerDto playerDto)
        {
            if (playerDto == null || id != playerDto.Id)
            {
                return BadRequest("Invalid player data"); // Return 400 if request body is invalid or ID mismatch
            }

            var existingPlayer = playerService.GetPlayerById(id);
            if (existingPlayer == null)
            {
                return NotFound(); // Return 404 if player not found
            }

            // Update the existing player with new data
            existingPlayer.Name = playerDto.Name;
            existingPlayer.Height = playerDto.Height;
            existingPlayer.Weight = playerDto.Weight;
            existingPlayer.Age = playerDto.Age;
            existingPlayer.Blocking = playerDto.Blocking;
            existingPlayer.Attacking = playerDto.Attacking;
            existingPlayer.Serving = playerDto.Serving;
            existingPlayer.Passing = playerDto.Passing;
            existingPlayer.Setting = playerDto.Setting;

            playerService.UpdatePlayer(existingPlayer);

            return NoContent(); // Return 204 on successful update
        }

        // DELETE: api/players/{id}
        [HttpDelete("{id}")]
        public IActionResult DeletePlayer(Guid id)
        {
            var existingPlayer = playerService.GetPlayerById(id);
            if (existingPlayer == null)
            {
                return NotFound(); // Return 404 if player not found
            }

            playerService.DeletePlayer(id);

            return NoContent(); // Return 204 on successful deletion
        }
    }
}
