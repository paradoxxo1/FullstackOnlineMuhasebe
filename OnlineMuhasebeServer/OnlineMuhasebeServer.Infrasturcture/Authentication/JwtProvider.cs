﻿using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OnlineMuhasebeServer.Application.Abstractions;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnlineMuhasebeServer.Infrasturcture.Authentication
{
    public sealed class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions _jwtOptions;

        public JwtProvider(IOptions<JwtOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
        }

        public string CreateToken(AppUser user, List<string> roles)
        {
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.NameLastName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Authentication, user.Id),
                new Claim(ClaimTypes.Role, String.Join(",", roles))
            };

            JwtSecurityToken jwtSecurityToken = new(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)), SecurityAlgorithms.HmacSha256));

            string token = new JwtSecurityTokenHandler()
                .WriteToken(jwtSecurityToken);

            return token;
        }
    }
}
