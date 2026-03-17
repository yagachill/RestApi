using Microsoft.AspNetCore.Mvc;
using restApi.Data;
using restApi.Models;
using restApi.Repositories;

namespace restApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UserRepository _userRepository;
    private readonly AppDbContext _db;
    public UsersController(AppDbContext db)
    {
        _db = db;
    }

    // POST api/users 'Lager bruker'
    [HttpPost]
    public IActionResult Create(User user)
    {
        _db.Users.Add(user);
        _db.SaveChanges();
        return Ok(user); // Returnerer brukeren med ID generert av databasen
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        Console.WriteLine($"ID received: {id}"); //Logger hvilken ID som skal oppdateres
        
        var user = _db.Users.Find(id);
        if (user == null)
        {
            return NotFound("User not found");
        }
        
        _db.Users.Remove(user);
        _db.SaveChanges();
        return Ok("Delete works");
    } 
    
    
    // PUT api/user{id}
    [HttpPut("{id}")]
    public IActionResult Update(int id, User updatedUser)
    {
        // Finn eksisterende bruker i databasen
        
        Console.WriteLine($"ID received: {id}"); //Logger hvilken ID som skal oppdateres
        
        var user = _db.Users.Find(id);
        if (user == null)
            return NotFound(" User Removed");
        
        // Oppdater felte
        user.Name = updatedUser.Name;
        user.Email = updatedUser.Email;
        user.Number = updatedUser.Number;

        // Lagre endringene+scv2    
        _db.SaveChanges();

        // Returner den oppdaterte brukeren
        return Ok(user);
    }
    
    // GET api/users 
    // GET api/users?search='navn'
    [HttpGet]
    public IActionResult GetAll([FromQuery] string? search)
    {
        var query = _db.Users.AsQueryable();
        if (!string.IsNullOrWhiteSpace(search))
        query = query.Where(u => u.Name.Contains(search));

        return Ok(query.ToList());
    }
    
    //Get api/users/{id}
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_db.Users.Find(id));
    }
    
    //Get api/user..
    
        
    
    
    
    
    
}