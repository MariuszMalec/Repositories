using Microsoft.EntityFrameworkCore;
using Repositories.Logic.Context;
using Repositories.Logic.Models;
using Repositories.Logic.Repositories;

namespace Repositories.Logic.Services
{
    public class ApplicationUserService : IRepository<ApplicationUser>
    {
        private readonly ApplicationDbContext _context;

        public ApplicationUserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(string id, ApplicationUser model)
        {
            if (model == null)
            {
                return false;
            }
            var user = await _context.ApplicationUsers.FindAsync(id);
            _context.ApplicationUsers.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAll()
        {
            var users = await _context.ApplicationUsers.ToListAsync();

            //var users = UsersStorage.Users.ToList();

            return users;
        }

        public IQueryable<ApplicationUser> GetAllQueryable()
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUser> GetById(string id)
        {
            var user = await _context.ApplicationUsers.FindAsync(id);
            return user;
        }

        public async Task<bool> Insert(ApplicationUser entity)
        {
            entity.Id = Guid.NewGuid().ToString();
            entity.Address = entity.Address;
            entity.PhoneNumber = entity.PhoneNumber;
            entity.Email = entity.Email;
            entity.FirstName = "";
            entity.LastName = entity.LastName;
            entity.CreatedAt = DateTime.Now;
            entity.AddressCorrespondence = "";
            entity.PhoneMobile = "";
            if (entity == null)
            {
                return false;
            }
            _context.ApplicationUsers.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(string id, ApplicationUser entity)
        {
            if (entity == null)
            {
                return false;
            }
            var user = await _context.ApplicationUsers.FindAsync(id);
            user.Id = user.Id;
            user.FirstName = entity.FirstName;
            user.LastName = entity.LastName;
            _context.ApplicationUsers.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
