using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using auction_portal_ubb.Features.User.Models.DTOs;
using auction_portal_ubb.Models;
using Microsoft.IdentityModel.Tokens;

namespace auction_portal_ubb.Features.User.Repositories
{
    public interface IUserRepository
    {
        Task<UserModel?> RegisterUser(UserRegisterDto userRegisterData);
        Task<UserModel> GetUser(int userId);
        Task<UserModel> UpdateUser(UserUpdateDto userUpdateData);
        Task DeleteUser(int userId);
        // Task<bool> LoginUser(string username, string password);
    }
}