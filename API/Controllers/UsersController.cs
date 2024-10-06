using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
[ApiController]
[Route("api/v1/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

    public UsersController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsersAsync()
        {
            var users = await _context.Users.ToListAsync();

            return users;
        }

     [HttpGet("{id:int}")]// api/v1/users/2
        public async  Task<ActionResult<AppUser>> GetUsersByIdAsync(int id)
        { 
            var users = await _context.Users.FindAsync(id);
            if (users == null) return NotFound();
            return users;
        }
    [HttpGet("{name}")]// api/v1/users/2
        public ActionResult<string> Ready(string name)
        { 
            return $"Hi {name}";
        }
    }
    
