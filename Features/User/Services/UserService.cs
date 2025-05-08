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
        private readonly IAddressRepository _addressRepository;
        private readonly UserProfileViewModel userProfileViewModel;


        public UserService(IUserRepository userRepository, IAddressRepository addressRepository)
        {
            _userRepository = userRepository;
            _addressRepository = addressRepository;
        }
        public async Task<UserProfileViewModel> GetAccountData(int userId)
        {
            try
            {
                var user = await _userRepository.GetById(userId);
                var address = await _addressRepository.GetByUserId(userId);
                if (user == null)
                {
                    throw new Exception("User not found.");
                }

                if (address == null)
                {
                    throw new Exception("Address not found.");
                }

                return new UserProfileViewModel
                {
                    Id = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    Email = user.Email,
                    Nick = user.Nick,
                    PhoneNumber = user.PhoneNumber,
                    Street = address.Street,
                    BuildingNumber = address.BuildingNumber,
                    ApartmentNumber = address.ApartmentNumber,
                    ZipCode = address.ZipCode,
                    City = address.City,
                    Country = address.Country,
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Service error during user retrieval.", ex);
            }
        }


        public async Task<int> UpdateAccountData(UserProfileUpdateViewModel userProfileUpdateViewModel)
        {
            try
            {
                var userUpdateData = userProfileUpdateViewModel.User;
                var addressUpdateData = userProfileUpdateViewModel.Address;

                var user = await _userRepository.UpdateAccount(userUpdateData);
                await _addressRepository.Update(addressUpdateData, userUpdateData.Id);

                return user.Id;
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
