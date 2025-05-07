using System;
using System.Threading.Tasks;
using auction_portal_ubb.Features.User.Models.DTOs;
using auction_portal_ubb.Models;
using auction_portal_ubb.Features.User.Repositories;

namespace auction_portal_ubb.Features.User.Services
{
    public class AuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<UserModel?> RegisterUser(UserRegisterDto userRegisterData)
        {
            try
            {
                var newUser = await _authRepository.RegisterUser(userRegisterData);
                return newUser;
            }
            catch (Exception ex)
            {
                throw new Exception("Service error during registration", ex);
            }
        }

        public bool LoginUser(string username, string password)
        {
            // TODO: Implement actual login logic, comparing hashed password etc.
            return true;
        }
    }
}
