using System.ComponentModel.DataAnnotations.Schema;

namespace MiddlewareProject.Model
{
    public class Register
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Pasword { get; set; }
        public string? Role { get; set; }
        [NotMapped]
        public string? Token { get; set; }
    }
}
