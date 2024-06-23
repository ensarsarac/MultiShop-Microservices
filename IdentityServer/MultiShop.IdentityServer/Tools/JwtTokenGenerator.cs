using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MultiShop.IdentityServer.Tools
{
    public class JwtTokenGenerator
    {
        public static TokenResponseViewModel GenerateToken(GetChectAppUserViewModel model)
        {
            var claims = new List<Claim>();
            if (!string.IsNullOrWhiteSpace(model.Role))
                claims.Add(new Claim(ClaimTypes.Role, model.Role));

            claims.Add(new Claim(ClaimTypes.NameIdentifier,model.Id.ToString()));

            if (!string.IsNullOrWhiteSpace(model.Username))
                claims.Add(new Claim("Username", model.Username));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefault.Key));
            var signInCredentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var expireDate = DateTime.UtcNow.AddMinutes(JwtTokenDefault.Expire);
            JwtSecurityToken token = new JwtSecurityToken(JwtTokenDefault.ValidIssuer, JwtTokenDefault.ValidAudience, claims, DateTime.UtcNow, expireDate, signInCredentials);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return new TokenResponseViewModel(handler.WriteToken(token),expireDate);
        }
    }
}
