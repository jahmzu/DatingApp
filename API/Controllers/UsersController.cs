using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

//when we create a new api controller, hot reload fails
[ApiController]
[Route("api/[controller]")] // /api/users
public class UsersController : ControllerBase
{
    private readonly DataContext _context; //conventionally _ is added to private

    //we need to inject something into this, how? we need acces to our db so we can query users and return to api controller
    //we create a constructor
    public UsersController(DataContext context)
    {
        _context = context;
    }

    //we need some api endpoints now
    [HttpGet]

    //async keyword in conjunction with keyword TASK<>
    // and AWAIT operator and method .ToListAsync (instead of
    // .ToList(); )
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await _context.Users.ToListAsync();
        return users; // gives us a 200 ok response
    }

    // another endpoint
    // specify a root parameter - 
    // below is also SYNCHRONUS
    [HttpGet("{id}")] // /api/users/2
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        // below is a request for a 'burger', waiter is waiting for 
        // burger to be cooked and cannot do anything else i.e. SYNCHRONUS
        // waiting for this request to complete 
        // ASYNCHRONUS, a waiter will send the order, do other things
        // wait for a bell that food is ready, then deliver
        // how do we make this code async?
        var user = await _context.Users.FindAsync(id);
        return user;
        // i.e. return _context.Users.Find(id);
    }
}
