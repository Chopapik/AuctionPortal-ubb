using System;
using System.Threading.Tasks;
using auction_portal_ubb.Features.User.Models.DTOs;
using auction_portal_ubb.Models;
using auction_portal_ubb.Features.User.Repositories;
using auction_portal_ubb.Features.User.ViewModels;

namespace auction_portal_ubb.Features.User.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserModel> GetAccountData(int userId)
        {
            try
            {
                var user = await _userRepository.GetById(userId);
                if (user == null)
                {
                    throw new Exception("User not found.");
                }

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("Service error during user retrieval.", ex);
            }
        }


        public async Task<UserModel> UpdateAccountData(UserUpdateDto userUpdateData)
        {
            try
            {
                return await _userRepository.UpdateAccount(userUpdateData);
            }
            catch (Exception ex)
            {
                throw new Exception("Service error during user update.", ex);
            }
        }

        public async Task Delete(int userId)
        {
            try
            {
                await _userRepository.DeleteAccount(userId);
            }
            catch (Exception ex)
            {
                throw new Exception("Service error during user deletion.", ex);
            }
        }
    }
}
