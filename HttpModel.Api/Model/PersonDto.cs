using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

#nullable disable
namespace HttpModel.Api.Model
{
    public class PersonDto
    {
        public string Name { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public string Email { get; set; }
    }
}
