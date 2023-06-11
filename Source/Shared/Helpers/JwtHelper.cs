using System;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ecommerce.Data.Entity;
using AutoMapper;
using ecommerce.Core.User;
using Microsoft.AspNetCore.Identity;

namespace ecommerce.Shared.Helpers
{
    public class JwtHelper
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly IConfiguration _configuration;

        public JwtHelper(UserManager<UserEntity> usermanager, IConfiguration configuration)
        {
            _userManager = usermanager;
            _configuration = configuration;
        }

        async public Task<string> Sign(UserEntity user)
        {
            var claims = await this.getAllUserClaims(user);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._configuration["Jwt:Secret"] ?? ""));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                  issuer: _configuration.GetValue<string>("Jwt:Issuer"),
                  audience: _configuration.GetValue<string>("Jwt:Audience"),
                  claims,
                  signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<List<Claim>> getAllUserClaims(UserEntity user)
        {
            var claims = new List<Claim> {
                new Claim("id", user.Id),
                new Claim(JwtRegisteredClaimNames.Email,user.Email ?? ""),
                new Claim(JwtRegisteredClaimNames.Name, user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var roles = await this._userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim("roles", role));
            }

            return claims;
        }

        public void Verify()
        {

        }
    }
}