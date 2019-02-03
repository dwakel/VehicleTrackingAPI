using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HatuaMVP.Api.Settings;
using HatuaMVP.Core.Domain;
using HatuaMVP.Core.EF;
using HatuaMVP.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace HatuaMVP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IAuthenticationService _authenticationService;
        private readonly AppSettings _appSettings;

        public LoginController(
            IAuthenticationService authenticationService,
            IOptions<AppSettings> appSettings)
        {
            _authenticationService = authenticationService;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]UserDto input, bool rememberMe)
        {
            #region test

            //var details = _context.Users.Where(user => user.Username == input.Username).FirstOrDefault();
            //PasswordService.GetPasswordHash(out byte[] passHash, details.PasswordSalt);
            //var results = await _signInManager.PasswordSignInAsync(
            //    input.Username,
            //    System.Text.Encoding.Default.GetString(passHash),
            //    rememberMe,
            //    lockoutOnFailure: false);

            //if (results.Succeeded)
            //{
            //    _logger.LogInformation("User logged in succesfully.");
            //}
            //Return the user info to client

            #endregion test

            var user = await _authenticationService.Authenticate(input.Email, input.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new
            {
                Id = user.EncodedId,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.Role,
                Token = tokenString
            });
        }
    }
}