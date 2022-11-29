
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TestApi.Models;
using TestApi.Repository;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : Controller
    {
        public IIdentity _identity;

        public TokenController(IIdentity identity)
        {
            _identity = identity;
        }

        [HttpPost]
        public IActionResult Post(User _userData)
        {

            if (_userData != null && _userData.Email != null && _userData.Password != null)
            {

                if (_identity != null)
                {
                    var token = _identity.getToken(_userData);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

       
    }
}
