using System;
using System.ComponentModel.DataAnnotations;

namespace auction_portal_ubb.Models
{

    public class Transaction
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public PaymentMethod PaymentMethod { get; set; }

        [MaxLength(50)]
        [Required]
        public ShippingMethod ShippingMethod { get; set; }

        [MaxLength(200)]
        [Required]
        public required string ShippingAddress { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        public int BuyerId { get; set; }

        public required User User { get; set; }
    }
}
