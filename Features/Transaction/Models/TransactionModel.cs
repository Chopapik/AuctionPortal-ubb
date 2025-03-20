using System;
using System.ComponentModel.DataAnnotations;

namespace auction_portal_ubb.Models
{

    public class TransactionModel
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public PaymentMethod PaymentMethod { get; set; }

        [MaxLength(50)]
        [Required]
        public ShippingMethod ShippingMethod { get; set; }

        public required DateTime TransactionDate { get; set; }

        public int? BuyerId { get; set; }

        public int? AuctionId { get; set; }

        public required UserModel User { get; set; }
        public required AuctionModel Auction { get; set; }

    }
}
