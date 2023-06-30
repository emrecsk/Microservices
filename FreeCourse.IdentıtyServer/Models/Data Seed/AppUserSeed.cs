using FreeCourse.IdentıtyServer.Models.IdentityTables;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreeCourse.IdentıtyServer.Models.Data_Seed
{
    public class AppUserSeed : IEntityTypeConfiguration<AppUser>
    {        
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            var firstuser = new AppUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "emrecsk",
                Email = "emrecsk@gmail.com",
                City = "Aarhus"
            };
            PasswordHasher<AppUser> passwordHasher = new ();
            firstuser.PasswordHash = passwordHasher.HashPassword(firstuser, "Password12*");

            builder.HasData(firstuser);
        }
    }
}
