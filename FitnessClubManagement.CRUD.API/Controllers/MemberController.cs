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
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(MemberDTO member)
        {
            await _memberService.CreateAsync(member);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _memberService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute]Guid id)
        {
            var entity = await _memberService.GetByIdAsync(id);

            if(entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(MemberDTO member)
        {
            var updated = await _memberService.UpdateAsync(member);

            if (updated)
                return Ok(member);
            return NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var deleted = await _memberService.DeleteAsync(id);

            if(deleted)
                return NoContent();
            return NotFound();
        }
    }
}
