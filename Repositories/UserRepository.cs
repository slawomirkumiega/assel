using Assel.Data;
using Assel.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assel.Repositories
{
    internal sealed class UserRepository : IUserRepository
    {
        private readonly AsselDbContext _db;

        public UserRepository(AsselDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _db.Users.Include(x => x.Facts).ToListAsync();
        }

        public async Task Add(User user)
        {
            await _db.Users.AddAsync(user);
        }

        public void Update(User user)
        {
            _db.Users.Update(user);
        }

        public async Task<IEnumerable<User>> FindByIds(IEnumerable<string> ids)
        {
            return await _db.Users.Include(x => x.Facts).Where(x => ids.Contains(x.Id)).ToListAsync();
        }
    }
}
