using API.Data;
using API.DataEntities;
using API.DTos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize]
public class UsersController : BaseApiController
    {
        private readonly IUserRepository _repository;

    public UsersController (UserRepository repository)
    {
        _repository = repository;
    }
    [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberResponse>>> GetAllAsync()
        {
            var users = await _repository.GetAllAsync();

            return  Ok(users);
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
            return user;
        }
    }
    
