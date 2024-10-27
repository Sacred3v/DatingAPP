using API.Data;
using API.DataEntities;
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

    public UsersController (IUserRepository repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberResponse>>> GetAllAsync()
        {
            var users = await _repository.GetAllAsync();
            var response = _mapper.Map<IEnumerable<MemberResponse>>(users);
            return Ok(response);
        }
     [HttpGet("{id:int}")]// api/users/2
        public async  Task<ActionResult<MemberResponse>> GetAllByIdAsync(int id)
        { 
            var users = await _repository.GetByIdAsync(id);
            if (users == null) return NotFound();
            return users;
        }
    [HttpGet("{username}")]// api/v1/users/2
        public async  Task<ActionResult<MemberResponse>> GetByIdAsync(string username)
        { 
            var user = await _repository.GetByUsernameAsync(username);
            if (user == null) return NotFound();
            return _mapper.Map<MemberResponse>(user);
        }
    }
    
