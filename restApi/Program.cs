using Microsoft.EntityFrameworkCore;
using restApi.Data;
using restApi.Models;

namespace restApi;

public class Program
{
    public static void Main(string[] args)
    {
        /*var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer("Server=localhost,1433;Database=MyDatabase;User Id=SA;Password=MissyZora22.;TrustServerCertificate=True;")
            .Options;
        using var db = new AppDbContext(options);

        try
        {
            if (db.Database.CanConnect())
                Console.WriteLine("✅ Database connection successful!");
            else
                Console.WriteLine("❌ Could not connect to database. Check server, database, user/password.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("❌ Exception: " + ex.Message);
        }*/
        
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        
        
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        var app = builder.Build();

        /*app.MapGet("/users", async (AppDbContext db) => await db.Users.ToListAsync());

        app.MapPost("/users", async (AppDbContext db, User user) =>
        {
            db.Users.Add(user);
            await db.SaveChangesAsync();
            return Results.Created($"/users/{user.Id}", user);
        });*/
        
        app.MapControllers();
        app.Run();
        
    }
}