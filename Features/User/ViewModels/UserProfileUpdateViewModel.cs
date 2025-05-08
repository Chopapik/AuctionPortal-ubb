using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using auction_portal_ubb.Features.User.Models.DTOs;

namespace auction_portal_ubb.Features.User.ViewModels
{
    public class UserProfileUpdateViewModel
    {
        public UserUpdateDto User { get; set; }
        public AddressUpdateDto Address { get; set; }
    }

}