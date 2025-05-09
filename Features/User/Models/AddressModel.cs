using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace auction_portal_ubb.Models
{
    public class AddressModel
    {

        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public required string Street { get; set; }

        [MaxLength(10)]
        [Required]
        public required string BuildingNumber { get; set; }

        [MaxLength(10)]
        public string? ApartmentNumber { get; set; }

        [MaxLength(10)]
        [Required]
        public required string ZipCode { get; set; }

        [MaxLength(50)]
        [Required]
        public required string City { get; set; }

        [MaxLength(50)]
        [Required]
        public required string Country { get; set; }

        public required int UserId { get; set; }
        public required UserModel User { get; set; }
    }
}