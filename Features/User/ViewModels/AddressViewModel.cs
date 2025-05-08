using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace auction_portal_ubb.Features.User.ViewModels
{
    public class AddressViewModel
    {
        [MaxLength(100)]
        public string? Street { get; set; }

        [MaxLength(10)]
        public string? BuildingNumber { get; set; }

        [MaxLength(10)]
        public string? ApartmentNumber { get; set; }

        [MaxLength(10)]
        public string? ZipCode { get; set; }

        [MaxLength(50)]
        [Required]
        public required string City { get; set; }

        [MaxLength(50)]
        public string? Country { get; set; }

        public bool HasMissingFields =>
            string.IsNullOrWhiteSpace(Street) ||
            string.IsNullOrWhiteSpace(BuildingNumber) ||
            string.IsNullOrWhiteSpace(ZipCode) ||
            string.IsNullOrWhiteSpace(City) ||
            string.IsNullOrWhiteSpace(Country);
    }
}