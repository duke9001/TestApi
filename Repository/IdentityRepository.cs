using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TestApi.Models;

namespace TestApi.Repository
{
    public class IdentityRepository : IIdentity
    {
        public IConfiguration _configuration;
        private readonly DBContext _context;
        private IUser _Iuser;

        public IdentityRepository(IConfiguration config
            , DBContext context
            , IUser user)
        {
            _configuration = config;
            _context = context;
            _Iuser = user;
        }

        public JwtSecurityToken getToken(User _user)
        {
            if (_user != null && _user.Email != null && _user.Password != null)
            {
                var user = _Iuser.GetUserbyEmailandPassword(_user.Email, _user.Password);

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("Id", user.UserId.ToString()),
                    new Claim("FirstName", user.FirstName),
                    new Claim("LastName", user.LastName),
                    new Claim("Email", user.Email)
                   };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                    return token;
                }
            }
            return null;
        }
    }
}
