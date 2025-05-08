using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using auction_portal_ubb.Features.User.Models.DTOs;
using auction_portal_ubb.Models;

namespace auction_portal_ubb.Features.User.Repositories
{
    public interface IAddressRepository
    {
        Task<AddressModel> GetByUserId(int userId);
        Task Update(AddressUpdateDto address, int UserId);
    }
}