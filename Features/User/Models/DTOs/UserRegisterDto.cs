using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace auction_portal_ubb.Features.User.Models.DTOs
{
    public class UserRegisterDto
    {

        [Required]
        public required string Email { get; set; }

        [MaxLength(256)]
        [Required]
        public required string Password { get; set; }

        [MaxLength(256)]
        [Required]
        public required string ConfirmPassword { get; set; }

    }
}