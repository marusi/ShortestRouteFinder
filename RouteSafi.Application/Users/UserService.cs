

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

using Microsoft.AspNetCore.Http;

using RouteSafi.Application.Services;
using RouteSafi.Application.Users.UserManager;

namespace RouteSafi.Application.Users
{
    public class UserService : IUserService
    {
        private UserManager<IdentityUser> _userManager;
        private IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(UserManager<IdentityUser> userManager, IConfiguration configuration,  IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

       
        public async Task<UserResponse> RegisterUserAsync(RegisterRequest model)
        {
            if (model == null)
                throw new NullReferenceException("Register Model is null");

            if (model.Password != model.ConfirmPassword)
                return new UserResponse
                {
                    Message = "Passwords do not match",
                    IsSuccess = false
                };

            var identityUser = new IdentityUser
            {
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                UserName = $"{model.FirstName}{model.LastName}",
                
            };

            var result = await _userManager.CreateAsync(identityUser, model.Password);

            if(result.Succeeded) {
                return new UserResponse
                {
                    Message = "User Created Succesfuly",
                    IsSuccess = true,
                   
                };
            }
            return new UserResponse
            {
                Message = "User did not create",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }

        public async Task<UserResponse> LoginUserAsync(LoginRequest model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return new UserResponse
                {
                    Message = "We seem not to have your email on board :( SORRY!",
                    IsSuccess = false
                };
            }

            var result = await _userManager.CheckPasswordAsync(user, model.Password);
            if(!result)
                return new UserResponse
                {
                    Message = "Invalid Password detected :( SORRY!",
                    IsSuccess = false
                };

            var claims = new[]
            {
                new Claim("Email", model.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName)
               

            };
        
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));

            var token = new JwtSecurityToken
            (
               issuer: _configuration["AuthSettings:Issuer"],
               audience: _configuration["AuthSettings:Audience"],
               claims: claims,
               expires: DateTime.Now.AddDays(8),
               signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

           
           

            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);
         

            return new UserResponse
            {
                Message = tokenAsString,
                IsSuccess = true,
                ExpiredDate = token.ValidTo,
       

             };

        }

      
    }
}
