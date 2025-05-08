using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using auction_portal_ubb.Features.User.Models.DTOs;
using auction_portal_ubb.Models;
using Microsoft.EntityFrameworkCore;

namespace auction_portal_ubb.Features.User.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext _context;

        public AddressRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<AddressModel> GetByUserId(int userId)
        {
            return await _context.Addresses
                .FirstOrDefaultAsync(a => a.UserId == userId);
        }

        public async Task Update(AddressUpdateDto address, int UserId)
        {
            var existingAddress = await _context.Addresses
                .FirstOrDefaultAsync(a => a.UserId == UserId);

            if (existingAddress != null && address != null)
            {
                existingAddress.Street = address.Street;
                existingAddress.City = address.City;
                existingAddress.ZipCode = address.ZipCode;
                existingAddress.Country = address.Country;

                _context.Addresses.Update(existingAddress);
                await _context.SaveChangesAsync();
            }
        }

    }
}