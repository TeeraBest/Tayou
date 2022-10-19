using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services_Proj.Models;
using Services_Proj.Services;
using System;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api_Proj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IConfiguration _configuration;

        private IJWT_AuthService _jWT_AuthService;
        public AuthController(IConfiguration configuration, IJWT_AuthService jWT_AuthService)
        {
            _configuration = configuration;
            _jWT_AuthService = jWT_AuthService;
        }
        [AllowAnonymous]
        [HttpPost(nameof(Auth))]
        public IActionResult Auth([FromBody] LoginModel data)
        {
            //bool isValid = _userService.IsValidUserInformation(data);
            var user = _jWT_AuthService.AuthenticateUser(data);

            if (user != null)
            {
                var tokenString = _jWT_AuthService.GenerateJwtToken(data.Username);
                return Ok(new { Token = tokenString, Message = "Success" });
            }
            return BadRequest("Please pass the valid Username and Password");
        }


        [HttpGet(nameof(GetResult))]
        public IActionResult GetResult()
        {
            return Ok("API Validated");
        }
        

    }



}
