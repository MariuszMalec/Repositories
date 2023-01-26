using Microsoft.EntityFrameworkCore;
using Repositories.Logic.Context;
using Repositories.Logic.Models;
using Repositories.Logic.Repositories;

namespace Repositories.Logic.Services
{
    public class UserService : IRepository<User>
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(string id, User model)
        {
            if (model == null)
            {
                return false;
            }
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var users = await _context.Users.ToListAsync();

            //var users = UsersStorage.Users.ToList();

            return users;
        }

        public IQueryable<User> GetAllQueryable()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetById(string id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
        }

        public async Task<bool> Insert(User entity)
        {
            entity.Name = entity.Name.ToUpper();
            entity.Id = Guid.NewGuid().ToString();
            if (entity == null)
            {
                return false;
            }
            _context.Users.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(string id, User entity)
        {
            if (entity == null)
            {
                return false;
            }
            var user = await _context.Users.FindAsync(id);
            user.Id = user.Id;
            user.Name = entity.Name;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
