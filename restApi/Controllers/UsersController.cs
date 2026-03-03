using Microsoft.AspNetCore.Mvc;
using restApi.Data;
using restApi.Models;

namespace restApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
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
            return NotFound("User not found");
        
        // Oppdater felte
        user.Navn = updatedUser.Navn;
        user.Mail = updatedUser.Mail;
        user.Telefon = updatedUser.Telefon;

        // Lagre endringene+scv2    
        _db.SaveChanges();

        // Returner den oppdaterte brukeren
        return Ok(user);
    }
    
    // GET api/users
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_db.Users.ToList());
    }

    
    //Get api/users/{id}
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_db.Users.Find(id));
    }
        
    
    
    
    
    
}