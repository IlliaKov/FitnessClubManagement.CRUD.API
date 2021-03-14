using FCManagement.BL.ABSTRACT;
using FCManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessClubManagement.CRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : Controller
    {
        private readonly IWorkoutService _workoutService;

        public WorkoutController(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(WorkoutDTO workout)
        {
            await _workoutService.CreateAsync(workout);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _workoutService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var entity = await _workoutService.GetByIdAsync(id);

            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] WorkoutDTO workout)//Errors
        {
            var updated = await _workoutService.UpdateAsync(workout);

            if (updated)
                return Ok(workout);
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var deleted = await _workoutService.DeleteAsync(id);

            if (deleted)
                return NoContent();
            return NotFound();
        }
    }
}
