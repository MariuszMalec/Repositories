using Repositories.Logic.Models;

namespace Repositories.Logic.Data
{
    public class UsersStorage
    {
        public static List<User> Users = new List<User>
        {
            new User {Id = Guid.NewGuid().ToString(), Name = "Michael"},
            new User {Id = Guid.NewGuid().ToString(), Name = "Jordan"}
        };
    }
}
