using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using auction_portal_ubb.Features.User.Models.DTOs;
using auction_portal_ubb.Models;

namespace auction_portal_ubb.Features.User.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
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
                // password hashing here
                PasswordHash = "hashPassword",
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

        public async Task<UserModel> GetUser(int userId)
        {
            try
            {
                var foundUser = await _context.Users.FindAsync(userId);

                if (foundUser == null)
                {
                    throw new Exception("User not found");
                }

                return foundUser;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while retrieving the user.", ex);
            }
        }

        public async Task<UserModel> UpdateUser(UserUpdateDto userUpdateData)
        {
            try
            {
                var userToUpdate = await _context.Users.FindAsync(userUpdateData.Id);

                if (userToUpdate == null)
                {
                    throw new Exception("User not found");
                }

                userToUpdate.Name = string.IsNullOrEmpty(userUpdateData.Name) ? userToUpdate.Name : userUpdateData.Name;
                userToUpdate.Surname = string.IsNullOrEmpty(userUpdateData.Surname) ? userToUpdate.Surname : userUpdateData.Surname;
                userToUpdate.Email = string.IsNullOrEmpty(userUpdateData.Email) ? userToUpdate.Email : userUpdateData.Email;
                userToUpdate.PhoneNumber = string.IsNullOrEmpty(userUpdateData.PhoneNumber) ? userToUpdate.PhoneNumber : userUpdateData.PhoneNumber;

                await _context.SaveChangesAsync();

                return userToUpdate;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while updating the user.", ex);
            }
        }

        public async Task DeleteUser(int userId)
        {
            try
            {
                var userToDelete = await _context.Users.FindAsync(userId);

                if (userToDelete == null)
                {
                    throw new Exception("User not found");
                }

                _context.Users.Remove(userToDelete);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while deleting the user.", ex);
            }
        }

        // public async Task<bool> LoginUser(string username, string password)
        // {
        //     return true;
        // }
    }
}