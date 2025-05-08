using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace auction_portal_ubb.Features.User.Models.DTOs
{
    public class UserUpdateDto
    {

        public int Id { get; set; }

        [MaxLength(50)]

        public string? Name { get; set; }

        [MaxLength(50)]

        public string? Surname { get; set; }

        [MaxLength(100)]

        public string? Email { get; set; }

        [MaxLength(15)]
        public string? PhoneNumber { get; set; }

    }
}