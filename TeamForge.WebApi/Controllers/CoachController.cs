﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamForge.Model;
using TeamForge.Service.Common;

namespace TeamForge.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachController : ControllerBase
    {
        private readonly ICoachService coachService;

        public CoachController(ICoachService coachService)
        {
            this.coachService = coachService;
        }

        [HttpGet("{coachId}")]
        public IActionResult GetCoach(Guid coachId)
        {
            var coach = coachService.GetCoachById(coachId);
            if (coach == null)
            {
                return NotFound(); // Coach not found
            }
            return Ok(coach);
        }

        [HttpGet]
        public IActionResult GetAllCoaches()
        {
            var coaches = coachService.GetAllCoaches();
            return Ok(coaches);
        }

        [HttpPost]
        public IActionResult AddCoach([FromBody] Coach coach)
        {
            coachService.AddCoach(coach);
            return CreatedAtAction(nameof(GetCoach), new { coachId = coach.Id }, coach);
        }

        [HttpPut("{coachId}")]
        public IActionResult UpdateCoach(Guid coachId, [FromBody] Coach coach)
        {
            if (coachId != coach.Id)
            {
                return BadRequest(); // Invalid request
            }

            coachService.UpdateCoach(coach);
            return NoContent();
        }

        [HttpDelete("{coachId}")]
        public IActionResult DeleteCoach(Guid coachId)
        {
            coachService.DeleteCoach(coachId);
            return NoContent();
        }
    }
}
