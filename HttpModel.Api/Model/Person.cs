using System.ComponentModel.DataAnnotations;
#nullable disable
namespace HttpModel.Api.Model
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
       
        public string PhoneNumber { get; set; }
        
        public string Email { get; set; }
    }
}
