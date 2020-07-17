

using RouteSafi.Application.Users.UserManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RouteSafi.Application.Services
{
    public interface IUserService
    {
        Task<UserResponse> RegisterUserAsync(RegisterRequest model);

        Task<UserResponse> LoginUserAsync(LoginRequest model);

    
    }
}
