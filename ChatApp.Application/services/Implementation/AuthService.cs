using ChatApp.Application.DTOs;
using ChatApp.Application.services.interfaces;
using ChatApp.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ChatApp.Application.services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly IConfiguration _configuration;

        const string password = "chatApp$pass123";
        public AuthService(UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }


        public async Task<Response> RegisterUserAsync(RegisterAppViewDTOs model)
        {
            if (model == null)
                throw new ArgumentNullException("Register Model is Null");


            var appUser = new AppUser
            {
                Email = model.Email,
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
            };
            var result = await _userManager.CreateAsync(appUser, password);
            if (result.Succeeded)
            {
                return new Response
                {
                    Message = "User Create Successfull",
                    IsSuccess = true,
                };
            }
            return new Response
            {
                Message = "User Not Create ",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }

        public async Task<Response> LoginUserAsync(LoginAppDTOs model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return new Response
                {
                    Message = "There is no user That Email",
                    IsSuccess = false,
                };
            }

            var result = await _userManager.CheckPasswordAsync(user, password);

            if (!result)
            {

            }

            var claims = new[]
            {
                new Claim("Email", user.Email),
                new Claim("Username", user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim("UserID",user.Id.ToString()),
                new Claim("Fullname",user.FirstName+""+user.LastName)

            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["AuthSettings:Issuer"],
                audience: _configuration["AuthSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            return new Response
            {
                Message = tokenAsString,
                IsSuccess = true,
                ExpireDate = token.ValidTo
            };

        }
    }
}
