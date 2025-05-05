using System;
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

        public UserModel GetUser(int userId)
        {
            try
            {
                var foundUser = _context.Users.Find(userId);

                if (foundUser == null)
                    throw new Exception("User not found");

                return foundUser;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while retrieving the user.", ex);
            }
        }

        public UserModel UpdateUser(UserUpdateDto userUpdateData)
        {
            try
            {
                var userToUpdate = _context.Users.Find(userUpdateData.Id);

                if (userToUpdate == null)
                    throw new Exception("User not found");

                userToUpdate.Name = string.IsNullOrEmpty(userUpdateData.Name) ? userToUpdate.Name : userUpdateData.Name;
                userToUpdate.Surname = string.IsNullOrEmpty(userUpdateData.Surname) ? userToUpdate.Surname : userUpdateData.Surname;
                userToUpdate.Email = string.IsNullOrEmpty(userUpdateData.Email) ? userToUpdate.Email : userUpdateData.Email;
                userToUpdate.PhoneNumber = string.IsNullOrEmpty(userUpdateData.PhoneNumber) ? userToUpdate.PhoneNumber : userUpdateData.PhoneNumber;

                _context.SaveChanges();
                return userToUpdate;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while updating the user.", ex);
            }
        }

        public void DeleteUser(int userId)
        {
            try
            {
                var userToDelete = _context.Users.Find(userId);

                if (userToDelete == null)
                    throw new Exception("User not found");

                _context.Users.Remove(userToDelete);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while deleting the user.", ex);
            }
        }
    }
}
