using System.Reflection.PortableExecutable;

namespace FreeCourse.IdentıtyServer.DTOs
{
    public class SignUpDTO
    {
        public SignUpDTO(string userName, string email, string password, string city)
        {
            UserName = userName;
            Email = email;
            Password = password;
            City = city;
        }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
    }
}
