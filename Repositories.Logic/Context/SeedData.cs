using Repositories.Logic.Models;

namespace Repositories.Logic.Context
{
    public static class SeedData
    {
        private static List<User> Users = new List<User>()//TODO insert startowe dane do bazy
        {
            new User {Id = Guid.NewGuid().ToString(), Name="Jordan"}
           };

        private static List<ApplicationUser> ApplicationUsers = new List<ApplicationUser>()//TODO insert startowe dane do bazy
        {
            new ApplicationUser {Id = Guid.NewGuid().ToString(),
                FirstName="Mikel",
                LastName="Jordan",
                CreatedAt=DateTime.Now,
                AddressCorrespondence="Chicago",
                Address="",
                Email="mj@example.com",
                PhoneMobile="",
                PhoneNumber=""
            }
           };

        public static List<User> GetAll()
        {
            return Users;
        }

        public static List<ApplicationUser> GetAllApplicationUsers()
        {
            return ApplicationUsers;
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

        public static async void SeedApplicationUsers(ApplicationDbContext context)
        {
            if (context.ApplicationUsers.Any())
            {
                return;
            }
            var user = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Mikel",
                LastName = "Jordan",
                CreatedAt = DateTime.Now,
                AddressCorrespondence = "Chicago",
                Address = "",
                Email = "mj@example.com",
                PhoneMobile = "",
                PhoneNumber = ""
            };

            context.ApplicationUsers.Add(user);
            await context.SaveChangesAsync();
        }
    }
}
