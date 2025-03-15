using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace auction_portal_ubb.Models
{
    public class Auction
    {
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 5)]
        [Required]
        public required string Title { get; set; }

        [StringLength(1000, MinimumLength = 10)]
        [Required]
        public required string Description { get; set; }

        [Range(0.01, 1000000)]
        [Required]
        public decimal Price { get; set; }

        [StringLength(255)]
        public string? ImagePath { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public int SellerId { get; set; }
        public required User Seller { get; set; }
    }
}
