using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Web.Business.Operations
{
    /// <summary>
    /// Used for generating tokens based on used and secret string.
    /// </summary>
    public interface ITokenOperation
    {
        /// <summary>
        /// Creates token based on user and secret string.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="secret"></param>
        /// <returns></returns>
        string CreateToken(string name, string secret);
    }
    public class TokenOperation : ITokenOperation
    {
        private const int EXPIRATION_DAYS = 7;

        public string CreateToken(string name, string secret)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, name),
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(EXPIRATION_DAYS),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
