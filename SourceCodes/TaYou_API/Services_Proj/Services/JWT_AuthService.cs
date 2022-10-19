using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services_Proj.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services_Proj.Services
{
    public interface IJWT_AuthService
    {
        LoginModel AuthenticateUser(LoginModel login);
        string GenerateJwtToken(string userName);
        string GenerateJwtToken(string userName, string GroupID);
    }

    public class JWT_AuthService : IJWT_AuthService
    {
        private readonly IConfiguration _configuration;
        public JWT_AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public LoginModel AuthenticateUser(LoginModel login) {
           return AuthenticateUserPriv(login);
        }

        private LoginModel AuthenticateUserPriv(LoginModel login)
        {
            LoginModel user = null;

            //Validate the User Credentials    
            //Demo Purpose, I have Passed HardCoded User Information    
            if (login.Password == "123")
            {
                user = new LoginModel { Username = "Jignesh Trivedi" };
            }
            return user;
        }

        /// <summary>
        /// Generate JWT Token after successful login.
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public string GenerateJwtToken(string userName)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", userName) }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public string GenerateJwtToken(string userName, string GroupID)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", userName), new Claim("GroupID", GroupID), new Claim("role", "view"), new Claim("role", "manage") }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

}
