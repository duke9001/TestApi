﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Models;

namespace TestApi.Repository
{
    public interface IIdentity
    {
        public JwtSecurityToken getToken(User user);
    }
}
