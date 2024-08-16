using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApi_Project
{
    public class JwtTokenGenerator
    {
        public string GenerateToken()
        {

            string secretKey = "ThisIsASecretKeyThatIsAtLeast32BytesLong!"; // 32 bytes uzunluğunda bir anahtar
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, "Member"));   

            JwtSecurityToken token = new JwtSecurityToken(issuer:"http://localhost",claims:null,audience:"http://localhost",notBefore:DateTime.Now,
                expires:DateTime.Now.AddMinutes(1),signingCredentials:credentials);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            
            return handler.WriteToken(token);
        }

    }
}
