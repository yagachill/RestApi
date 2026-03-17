using restApi.Data;
using restApi.Models;

namespace restApi.Repositories
{ 
    public class UserRepository
    {
        private readonly AppDbContext _db;

        public UserRepository(AppDbContext db)
        {
            _db = db;
        }

        public User GetUserById(int id) //User hentes fra Models
        {
            return _db.Users.Find(id);
        }
    }
}