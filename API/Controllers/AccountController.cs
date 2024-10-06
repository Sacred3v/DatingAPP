using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class AccountController(DataContext context) : BaseApiController
{
    [HttpPost("register")]
    public async Task<ActionResult<AppUser>> RegisterAsync(RegisterRequest request)
    {
        if(await UserExistsAsync(request.Username)) return BadRequest("Username is taken");
        using var hmac = new HMACSHA512();
        var usr = new AppUser{
            UserName = request.Username,
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password)),
            PasswordSalt = hmac.Key,
        };

        context.Users.Add(usr);
        await context.SaveChangesAsync();
        return usr;
    }

    private async Task<bool> UserExistsAsync(string username) => 
    await context.Users.AnyAsync(u => u.UserName.ToLower() == username.ToLower());
    
}