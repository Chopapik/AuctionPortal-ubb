using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using auction_portal_ubb.Features.User.Models.DTOs;
using auction_portal_ubb.Models;

namespace auction_portal_ubb.Features.User.Services
{
    public class UserService
    {

        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public UserModel? RegisterUser(UserRegisterDto userRegisterData)
        {
            if (userRegisterData.Password != userRegisterData.ConfirmPassword)
            {
                return null;
                //send error message
            }


            var newUser = new UserModel
            {
                Name = "",
                Surname = "",
                Nick = "",
                Email = userRegisterData.Email,
                //hashed password will be here
                PasswordHash = "hashPassword",
                PhoneNumber = "",
                CreatedAt = DateTime.Now
            };

            try
            {
                _context.Add(newUser);
                _context.SaveChanges();
                return newUser;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while registering the user.", ex);
            }
        }

    }
}