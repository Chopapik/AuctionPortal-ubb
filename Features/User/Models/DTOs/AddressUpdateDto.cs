using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace auction_portal_ubb.Features.User.Models.DTOs
{
    public class AddressUpdateDto
    {
        [MaxLength(255)]
        [Required]
        public string? Street { get; set; }

        [MaxLength(10)]
        [Required]
        public required string BuildingNumber { get; set; }

        [MaxLength(10)]
        [Required]
        public required string? ApartmentNumber { get; set; }

        [MaxLength(10)]
        [Required]
        public required string ZipCode { get; set; }

        [MaxLength(50)]
        [Required]
        public required string City { get; set; }

        [MaxLength(50)]
        [Required]
        public required string Country { get; set; }

    }
}