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
using Microsoft.AspNetCore.Mvc.ModelBinding;

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

        [HttpDelete("{id}")]
        public void  DeleteFamilyMember(string id)
        {
            _familyMemberService.DeleteFamilyMember(id);
        }
        
        [HttpGet]
        public ActionResult<FamilyMembersDto> GetFamilyMembers()
        {
            try
            {
                var members = _familyMemberService.GetFamilyMembers().Select(member => new FamilyMemberDto
                {
                    Id = member.Id,
                    Name = member.Name,
                    Phone = member.Phone,
                    Picture = member.Picture,
                    Location = member.Location
                }).ToList();

                return Ok(new FamilyMembersDto
                {
                    List = members
                });

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<FamilyMemberDto> GetFamilyMember(string id)
        {
            try
            {
                var familyMember = _familyMemberService.GetFamilyMember(id);
                return Ok(new FamilyMemberDto
                {
                    Id = familyMember.Id,
                    Name = familyMember.Name,
                    Phone = familyMember.Phone,
                    Picture = familyMember.Picture,
                    Location = familyMember.Location
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<FamilyMemberDto> UpdateFamilyMember(string id, FamilyMemberDto dto)
        {
            var member = _familyMemberService.UpdateFamilyMember(new FamilyMember
            {
                Id = dto.Id,
                Name = dto.Name,
                Phone = dto.Phone,
                Picture = dto.Picture,
                Location = dto.Location
            });
            return Ok(dto);
        }
    }
}
