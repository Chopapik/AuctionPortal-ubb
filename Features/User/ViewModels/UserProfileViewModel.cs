using System.ComponentModel.DataAnnotations;

namespace auction_portal_ubb.Features.User.ViewModels
{
    public class UserProfileViewModel
    {
        public int Id { get; set; }

        // Personal Data
        [MaxLength(50)]
        public string? Name { get; set; }

        [MaxLength(50)]
        public string? Surname { get; set; }

        [MaxLength(50)]
        public string? Nick { get; set; }

        [MaxLength(100)]
        [Required]
        public required string Email { get; set; }

        // Contact Info
        [MaxLength(15)]
        public string? PhoneNumber { get; set; }

        // Address
        [MaxLength(100)]
        public string? Street { get; set; }

        [MaxLength(10)]
        public string? BuildingNumber { get; set; }

        [MaxLength(10)]
        public string? ApartmentNumber { get; set; }

        [MaxLength(10)]
        public string? ZipCode { get; set; }

        [MaxLength(50)]
        [Required]
        public required string City { get; set; }

        [MaxLength(50)]
        public string? Country { get; set; }

        // Validation helpers
        public bool HasMissingFields =>
            IsEmpty(Name) ||
            IsEmpty(Surname) ||
            IsEmpty(Nick) ||
            IsEmpty(PhoneNumber) ||
            HasMissingAddressFields;

        public bool HasMissingAddressFields =>
            IsEmpty(Street) &&
            IsEmpty(BuildingNumber) &&
            IsEmpty(ApartmentNumber) &&
            IsEmpty(ZipCode) &&
            IsEmpty(City) &&
            IsEmpty(Country);

        private static bool IsEmpty(string? value) =>
            string.IsNullOrWhiteSpace(value);

    }
}
