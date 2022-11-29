using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApi.Models;
using TestApi.Repository;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUser _Iuser;

        public UsersController(IUser user)
        {
            _Iuser = user;
        }

        // GET: api/Users
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(_Iuser.GetUsers());
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<User> GetUser(long id)
        {
            var user = _Iuser.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult PutUser(long id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            try
            {
                _Iuser.PutUser(id, user);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        [HttpPost]
        public ActionResult<User> PostUser(User user)
        {
            try
            {
                bool result = _Iuser.PostUser(user);
                if (result == true)
                {
                    return CreatedAtAction("GetUser", new { id = user.UserId }, user);
                }
            }
            catch
            {
                return BadRequest();
            }

            return BadRequest();
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult<User> DeleteUser(long id)
        {
            var result = _Iuser.DeleteUser(id);
            if (result == true)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        private bool UserExists(long id)
        {
            return _Iuser.UserExists(id);
        }
    }
}
