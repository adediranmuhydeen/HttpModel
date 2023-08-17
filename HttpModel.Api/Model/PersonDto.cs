#nullable disable
using System.ComponentModel.DataAnnotations;

namespace HttpModel.Api.Model
{
    public class PersonDto
    {
        [Required]
        public string Name { get; set; }
        [Required, Phone]
        public string PhoneNumber { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
    }
}
