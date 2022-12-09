using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using DownNotifierWebApi.DataAccess.Contexts;
using DownNotifierWebApi.DataAccess.Entities;
using System.Linq;
using DownNotifierWebApi.JWT;
using DownNotifierWebApi.Statics;
using DownNotifierWebApi.Models.Authentication;

namespace DownNotifierWebApi.Controllers
{
    [AllowAnonymous]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        public ApplicationDbContext Context { get; set; }
        public JwtSettings JwtSettings { get; set; }

        public AuthenticationController(ApplicationDbContext context, JwtSettings jwtSettings)
        {
            this.Context = context;
            this.JwtSettings = jwtSettings;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string userName, string password)
        {
            try
            {
                var getUserDetails = Context.Set<Users>().FirstOrDefault(x => x.UserName.ToLower() == userName);

                if (getUserDetails == null)
                {
                    return NotFound();
                }

                if (getUserDetails.Password != password)
                {
                    return StatusCode(500, "invalid password");
                }

                SymmetricSecurityKey symmetricSecurityKey = new(Encoding.UTF8.GetBytes(JwtSettings.Secret));

                JwtSecurityToken jwtSecurityToken = new(
                    claims: GenerateClaims(getUserDetails),
                    issuer: JwtSettings.Issuer,
                    audience: JwtSettings.Audience,
                    expires: DateTime.Now.AddMinutes(JwtSettings.TokenLifeTime.TotalMinutes),
                    signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
                );

                JwtSecurityTokenHandler tokenHandler = new();

                var tokenAsStr = tokenHandler.WriteToken(jwtSecurityToken);

                UserResponseDto dto = new UserResponseDto()
                {
                    UserId = getUserDetails.Id,
                    UserName = getUserDetails.UserName,
                    UserToken = tokenAsStr
                };

                return Ok(dto);
            }
            catch (System.Exception)
            {
                return StatusCode(500, "internal server error!");
            }
        }

        [HttpGet]
        [Route("GetMyDetails")]
        [Authorize]
        public IActionResult GetMyDetails(long id)
        {
            try
            {
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(500, "internal server error!");
            }
        }

        private static Claim[] GenerateClaims(Users user)
        {
            return new[]
            {
                new Claim(UserClaimsType.Id, user.Id.ToString()),
                new Claim(UserClaimsType.UserName, user.UserName),
            };
        }
    }
}