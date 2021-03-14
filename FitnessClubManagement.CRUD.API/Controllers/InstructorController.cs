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
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorService _instructorService;

        public InstructorController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(InstructorDTO instructor)
        {
            await _instructorService.CreateAsync(instructor);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _instructorService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var entity = await _instructorService.GetByIdAsync(id);

            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] InstructorDTO instructor)//Errors
        {
            var updated = await _instructorService.UpdateAsync(instructor);

            if (updated)
                return Ok(instructor);
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var deleted = await _instructorService.DeleteAsync(id);

            if (deleted)
                return NoContent();
            return NotFound();
        }
    }
}
