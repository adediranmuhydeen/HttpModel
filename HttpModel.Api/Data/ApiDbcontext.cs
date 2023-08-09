using HttpModel.Api.Model;
using Microsoft.EntityFrameworkCore;
#nullable disable
namespace HttpModel.Api.Data
{
    public class ApiDbcontext : DbContext
    {
        public ApiDbcontext(DbContextOptions<ApiDbcontext> options) : base(options) 
        { 
        }
        public DbSet<Person> Persons { get; set; }
    }
}
