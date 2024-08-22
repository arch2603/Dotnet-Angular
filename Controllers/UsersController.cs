using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API;

[ApiController]
[Route("api/[controller]")]
public class UsersController(DataContext context) : ControllerBase
{
    //this is replace new syntax by C# called primary constructor
    // private readonly DataContext _context;
    // public UsersController(DataContext context)
    // {
    //     this._context = context;
    // }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>>GetUsers()
    {
        var users = await context.Users.ToListAsync();

        //return Ok(users);
        return users;
    }

    
    [HttpGet("{id:int}")] //api/user/id
    public async Task<ActionResult<AppUser>>GetUser(int id)
    {
        var user = await context.Users.FindAsync(id);

        Console.WriteLine(user);
        
        if(user == null) return NotFound();

        //return Ok(users);
        return user;
    }


}