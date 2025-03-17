using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace auction_portal_ubb.Models
{
    public class User
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public required string Name { get; set; }

        [MaxLength(50)]
        [Required]
        public required string Surname { get; set; }

        [MaxLength(50)]
        [Required]
        public required string Nick { get; set; }

        [MaxLength(100)]
        [Required]
        public required string Email { get; set; }

        [MaxLength(256)]
        [Required]
        public required string PasswordHash { get; set; }

        [MaxLength(15)]
        [Required]
        public required string PhoneNumber { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public required Address Address { get; set; }
        public required List<Transaction> Transactions { get; set; }
        public required List<Auction> Auctions { get; set; }



    }
}
