using BookHosting.Application.Common.Interfaces.Authentication;
using BookHosting.Application.Common.Interfaces.Services;
using BookHosting.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookHosting.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly JwtSettings _jwtSettings;


        public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtSettingsOptions
            )
        {
            _dateTimeProvider = dateTimeProvider;
            _jwtSettings = jwtSettingsOptions.Value;
        }

        public string GenerateToken(User user)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName,user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName,user.LastName)

            };

            var securityToken = new JwtSecurityToken(issuer:_jwtSettings.Issuer,claims: claims,signingCredentials:signingCredentials,
                expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),audience: _jwtSettings.Audience);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);


        }
    }
}
