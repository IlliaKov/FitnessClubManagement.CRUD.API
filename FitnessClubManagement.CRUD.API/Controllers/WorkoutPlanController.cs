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
    public class WorkoutPlanController : Controller
    {
        private readonly IWorkoutPlanService _workoutPlanService;

        public WorkoutPlanController(IWorkoutPlanService workoutPlanService)
        {
            _workoutPlanService = workoutPlanService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(WorkoutPlanDTO workoutPlan)
        {
            await _workoutPlanService.CreateAsync(workoutPlan);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _workoutPlanService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var entity = await _workoutPlanService.GetByIdAsync(id);

            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] WorkoutPlanDTO workoutPlan)//Errors
        {
            var updated = await _workoutPlanService.UpdateAsync(workoutPlan);

            if (updated)
                return Ok(workoutPlan);
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var deleted = await _workoutPlanService.DeleteAsync(id);

            if (deleted)
                return NoContent();
            return NotFound();
        }
    }
}
