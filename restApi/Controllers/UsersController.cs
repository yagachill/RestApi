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

    // POST api/Persons
    [HttpPost]
    public IActionResult Create(User user)
    {
        _db.Users.Add(user);
        _db.SaveChanges();
        return Ok(user); // Returnerer brukeren med ID generert av databasen
    }

    // GET api/users
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_db.Users.ToList());
    }
}