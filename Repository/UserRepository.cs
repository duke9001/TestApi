using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Models;

namespace TestApi.Repository
{
    public class UserRepository : IUser
    {
        private readonly DBContext _context;
        public UserRepository(DBContext context)
        {
            _context = context;
        }
        public bool DeleteUser(long id)
        {
            try
            {
                var user = _context.Users.Find(id);
                if (user == null)
                {
                    return false;
                }

                _context.Users.Remove(user);
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public User GetUser(long id)
        {
            var user = _context.Users.Find(id);
            return user;
        }

        public User GetUserbyEmailandPassword(string email, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public bool PostUser(User user)
        {
            if (user == null)
            {
                return false;
            }
            else
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return true;
            }
        }

        public bool PutUser(long id, User user)
        {
            if (id != user.UserId)
            {
                return false;
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
            return true;
        }

        public bool UserExists(long id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
