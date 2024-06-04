using Microsoft.AspNetCore.Mvc;
using TeamForge.Model;
using TeamForge.Service.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TeamForge.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMatchService matchService;

        public MatchController(IMatchService matchService)
        {
            this.matchService = matchService;
        }

        // GET: api/match
        [HttpGet]
        public ActionResult<IEnumerable<Match>> GetAllMatches()
        {
            var matches = matchService.GetAllMatches();
            return Ok(matches);
        }

        // GET: api/match/{id}
        [HttpGet("{id}")]
        public ActionResult<Match> GetMatchById(Guid id)
        {
            var match = matchService.GetMatchById(id);
            if (match == null)
            {
                return NotFound(); // Return 404 Not Found if match not found
            }
            return Ok(match);
        }

        // POST: api/match
        [HttpPost]
        public IActionResult AddMatch([FromBody] Match match)
        {
            if (match == null)
            {
                return BadRequest(); // Return 400 Bad Request if match data is invalid
            }
            matchService.AddMatch(match);
            return CreatedAtAction(nameof(GetMatchById), new { id = match.Id }, match);
        }

        // PUT: api/match/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateMatch(Guid id, [FromBody] Match match)
        {
            if (match == null || id != match.Id)
            {
                return BadRequest(); // Return 400 Bad Request if match data is invalid or ID mismatch
            }
            var existingMatch = matchService.GetMatchById(id);
            if (existingMatch == null)
            {
                return NotFound(); // Return 404 Not Found if match not found
            }
            matchService.UpdateMatch(match);
            return NoContent(); // Return 204 No Content on successful update
        }

        // DELETE: api/match/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteMatch(Guid id)
        {
            var existingMatch = matchService.GetMatchById(id);
            if (existingMatch == null)
            {
                return NotFound(); // Return 404 Not Found if match not found
            }
            matchService.DeleteMatch(id);
            return NoContent(); // Return 204 No Content on successful deletion
        }
    }

}
