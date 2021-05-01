using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ePunla.Common.Utilitites.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ePunla.Common.Utilitites.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _symmetricSecurityKey;

        public TokenService(IConfiguration configuration)
        {
            _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:Secret"]));
        }

        public string CreateToken(string userId)
        {
            var claims = new List<Claim>
           {
               new Claim(JwtRegisteredClaimNames.NameId,userId)
           };

            var creds = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha512Signature);

            var tokenDesciptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDesciptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
