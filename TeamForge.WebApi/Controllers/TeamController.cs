using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamForge.Model;
using TeamForge.Service.Common;

namespace TeamForge.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService teamService;

        public TeamController(ITeamService teamService)
        {
            this.teamService = teamService;
        }

        // GET: api/team/{id}
        [HttpGet("{id}")]
        public IActionResult GetTeam(Guid id)
        {
            var team = teamService.GetTeamById(id);
            if (team == null)
            {
                return NotFound(); // Return 404 if team not found
            }
            return Ok(team);
        }

        // GET: api/team
        [HttpGet]
        public IActionResult GetAllTeams()
        {
            var teams = teamService.GetAllTeams();
            return Ok(teams);
        }

        // POST: api/team
        [HttpPost]
        public IActionResult AddTeam([FromBody] Team team)
        {
            if (team == null)
            {
                return BadRequest(); // Return 400 if request body is empty
            }

            teamService.AddTeam(team);

            return CreatedAtAction(nameof(GetTeam), new { id = team.Id }, team);
        }

        // PUT: api/team/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateTeam(Guid id, [FromBody] Team team)
        {
            if (team == null || id != team.Id)
            {
                return BadRequest(); // Return 400 if request body is invalid or ID mismatch
            }

            var existingTeam = teamService.GetTeamById(id);
            if (existingTeam == null)
            {
                return NotFound(); // Return 404 if team not found
            }

            teamService.UpdateTeam(team);

            return NoContent(); // Return 204 on successful update
        }

        // DELETE: api/team/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteTeam(Guid id)
        {
            var existingTeam = teamService.GetTeamById(id);
            if (existingTeam == null)
            {
                return NotFound(); // Return 404 if team not found
            }

            teamService.DeleteTeam(id);

            return NoContent(); // Return 204 on successful deletion
        }
    }
}
