using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace auction_portal_ubb.Features.User.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string? Name { get; set; }

        [MaxLength(50)]
        public string? Surname { get; set; }

        [MaxLength(100)]
        [Required]
        public required string Email { get; set; }

        [MaxLength(50)]
        public string? Nick { get; set; }

        [MaxLength(15)]
        public string? PhoneNumber { get; set; }

        public bool HasMissingFields =>
            string.IsNullOrWhiteSpace(Name) ||
            string.IsNullOrWhiteSpace(Surname) ||
            string.IsNullOrWhiteSpace(Nick) ||
            string.IsNullOrWhiteSpace(PhoneNumber);
    }

}