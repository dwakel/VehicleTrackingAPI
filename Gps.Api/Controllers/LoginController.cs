using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Gps.Api.Service;
using Gps.Api.Settings;
using Gps.Api.ViewModels;
using Gps.Core.Domain;
using Gps.Core.EF;
using Gps.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Gps.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IAuthenticationService _authenticationService;
        private ITokenService _token;

        public LoginController(
            IAuthenticationService authenticationService,
            ITokenService token)
        {
            _authenticationService = authenticationService;
            _token = token;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserDto userDto)
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

            var user = await _authenticationService.Authenticate(userDto.Email, userDto.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(new
            {
                Id = user.EncodedId,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = _token.BuildToken(user)
            });
        }
    }
}