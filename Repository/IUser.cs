using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Models;

namespace TestApi.Repository
{
    public interface IUser
    {
        public IEnumerable<User> GetUsers();
        public User GetUser(long id);
        public User GetUserbyEmailandPassword(string email, string password);
        public bool PutUser(long id, User user);
        public bool PostUser(User user);
        public bool DeleteUser(long id);
        public bool UserExists(long id);

    }
}
