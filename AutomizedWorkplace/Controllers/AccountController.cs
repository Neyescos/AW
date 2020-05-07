using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using AutomizedWorkplace.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WorkplaceBLL.DTO;
using WorkplaceBLL.Interfaces;
using WorkplaceBLL.Services;

namespace AutomizedWorkplace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        IAuthorizationService service;
        IMapper mapper;
       
        public AccountController(IAuthorizationService serv, IMapper mapper)
        {
            this.mapper = mapper;
            service = serv;
        }
        // G
        [HttpPost("/token")]
        public IActionResult Token(string username, string password)
        {
            var identity = GetIdentity(username, password);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            return Json(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = service.Registration(mapper.Map<UserDTO>(model));
            result.Start();

            if (result.IsCanceled)
            {
                return BadRequest(ModelState);
            }

            return Ok();
        }

        private ClaimsIdentity GetIdentity(string username, string password)
        {
            UserDTO person = service.Login(password, username).Result;
            if (person != null)
            {
                
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimsIdentity.DefaultNameClaimType,  person.Name),
                        new Claim(ClaimsIdentity.DefaultRoleClaimType,  person.Role)
                    };

                    ClaimsIdentity claimsIdentity =
                    new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                        ClaimsIdentity.DefaultRoleClaimType);
                    return claimsIdentity;

                
            }

            // если пользователя не найдено
            return null;
        }

    }
}

