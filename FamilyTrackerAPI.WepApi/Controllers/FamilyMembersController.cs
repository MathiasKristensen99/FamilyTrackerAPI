using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamilyTrackerAPI.Core;
using FamilyTrackerAPI.Core.IServices;
using FamilyTrackerAPI.WepApi.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FamilyTrackerAPI.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyMembersController : ControllerBase
    {
        private readonly IFamilyMemberService _familyMemberService;

        public FamilyMembersController(IFamilyMemberService memberService)
        {
            _familyMemberService = memberService;
        }

        [HttpPost]
        public ActionResult<FamilyMemberDto> CreateFamilyMember([FromBody] FamilyMemberDto dto)
        {
            var memberFromDto = new FamilyMember
            {
                Name = dto.Name,
                Phone = dto.Phone,
                Picture = dto.Picture,
                Location = dto.Location
            };

            try
            {
                var newFamilyMember = _familyMemberService.CreateFamilyMember(memberFromDto);
                return Created($"https://localhost:5001/api/familymembers/{newFamilyMember.Id}", newFamilyMember);
            }
            catch (ArgumentException ae)
            {
                return BadRequest(ae.Message);
            }
        }
    }
}
