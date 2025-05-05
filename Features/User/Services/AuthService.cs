using System;
using auction_portal_ubb.Features.User.Models.DTOs;
using auction_portal_ubb.Models;

namespace auction_portal_ubb.Features.User.Services
{
    public class AuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public UserModel? RegisterUser(UserRegisterDto userRegisterData)
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
                PasswordHash = "hashPassword", // TODO: implement real hashing
                PhoneNumber = "",
                CreatedAt = DateTime.Now
            };

            try
            {
                _context.Users.Add(newUser);
                _context.SaveChanges();
                return newUser;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while registering the user.", ex);
            }
        }

        public bool LoginUser(string username, string password)
        {
            // TODO: Implement actual login logic with hashing and credential verification
            return true;
        }
    }
}
