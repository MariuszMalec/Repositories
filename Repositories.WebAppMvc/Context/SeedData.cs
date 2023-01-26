using Repositories.WebAppMvc.Models;
using System.Numerics;

namespace Repositories.WebAppMvc.Context
{
    public static class SeedData
    {
        private static List<User> Users = new List<User>()//TODO insert startowe dane do bazy
        {
            new User {Id = Guid.NewGuid().ToString(), Name="Jordan"}
           };

        public static List<User> GetAll()
        {
            return Users;
        }
        public static async void Seed(ApplicationDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }
            var user = new User()
            {
                Name = "Jordan",
            };

            context.Users.Add(user);
            await context.SaveChangesAsync();
        }
    }
}
