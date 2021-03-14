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
    public class MembershipController : Controller
    {
        private readonly IMembershipService _membershipService;

        public MembershipController(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(MembershipDTO membership)
        {
            await _membershipService.CreateAsync(membership);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _membershipService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var entity = await _membershipService.GetByIdAsync(id);

            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] MembershipDTO membership)//Errors
        {
            var updated = await _membershipService.UpdateAsync(membership);

            if (updated)
                return Ok(membership);
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var deleted = await _membershipService.DeleteAsync(id);

            if (deleted)
                return NoContent();
            return NotFound();
        }
    }
}
