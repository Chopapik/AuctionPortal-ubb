using System;
using System.Threading.Tasks;
using auction_portal_ubb.Features.User.Models.DTOs;
using auction_portal_ubb.Models;

namespace auction_portal_ubb.Features.User.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _context;

        public AuthRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserModel?> RegisterUser(UserRegisterDto userRegisterData)
        {
            if (userRegisterData.Password != userRegisterData.ConfirmPassword)
            {
                return null;
            }

            var newUser = new UserModel
            {
                Name = "",
                Surname = "",
                Nick = "",
                Email = userRegisterData.Email,
                PasswordHash = "hashPassword", // TODO: real password hashing
                PhoneNumber = "",
                CreatedAt = DateTime.Now
            };

            try
            {
                await _context.AddAsync(newUser);
                await _context.SaveChangesAsync();
                return newUser;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while registering the user.", ex);
            }
        }

        // Możesz dodać logikę logowania tutaj w przyszłości
    }
}
