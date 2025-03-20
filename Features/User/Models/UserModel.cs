using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace auction_portal_ubb.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public required string Name { get; set; }

        [MaxLength(50)]
        [Required]
        public required string Surname { get; set; }

        [MaxLength(50)]
        public required string Nick { get; set; }

        [MaxLength(100)]
        public required string Email { get; set; }

        [MaxLength(256)]
        [Required]
        public required string PasswordHash { get; set; }

        [MaxLength(15)]
        [Required]
        public string? PhoneNumber { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public AddressModel? Address { get; set; }
        public List<TransactionModel>? Transactions { get; set; }
        public List<AuctionModel>? Auctions { get; set; }

    }
}
