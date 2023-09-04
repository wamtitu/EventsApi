using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Events.Models;
using Events.Requests;
using Events.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Events.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsers _userService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _iconfig;

        public AuthController(IUsers userService, IMapper mapper, IConfiguration iconfig)
        {
            _iconfig = iconfig;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<string>> RegisterUser(CreateUser newUser){
            var user = _mapper.Map<User>(newUser);
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            var res = await _userService.CreateUsersAsync(user);

            return CreatedAtAction(nameof(RegisterUser), res);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(AddLogin newLogin){
            var user = await _userService.GetUserByEmail(newLogin.Email);
            if(user == null){
                return "User not found";
            }
            var validPassword = BCrypt.Net.BCrypt.Verify(newLogin.Password, user.Password);
            if(!validPassword){
                return "invalid credentials";
            }
            
            var Token = CreateToken(user);
            return (Token);
        }

        private string CreateToken(User user){
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_iconfig["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("Role", user.Role));
            claims.Add(new Claim("Names", user.Name));
            claims.Add(new Claim("Sub", user.UserId.ToString()));

             var token = new JwtSecurityToken(
                _iconfig["Jwt:Issuer"], _iconfig["Jwt:Audience"], signingCredentials:credentials,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1)
             );
              return new JwtSecurityTokenHandler().WriteToken(token);
        }
        
    }
}