using Microsoft.AspNetCore.Identity;

namespace FreeCourse.IdentıtyServer.Models.IdentityTables
{
    public class AppUser : IdentityUser
    {
        public string? City { get; set; }
    }
}
