using API.Data;
using API.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize]
public class UsersController : BaseApiController
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

    public UsersController (IUserRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberResponse>>> GetAllAsync()
        {
           var members = await _repository.GetMembersAsync();
           return Ok(members);
        }

    [HttpGet("{username}")]// api/v1/users/2
        public async  Task<ActionResult<MemberResponse>> GetByIdAsync(string username)
        { 
            var member = await _repository.GetMemberAsync(username);
            if (member == null) return NotFound();
            return member;
        }
    }
    
