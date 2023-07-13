using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MiddlewareProject.Model
{
    public class LoginUsers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        public string? UserEmail { get; set; }
        public DateTime LoginUser { get; set; }= DateTime.Now;
        public DateTime Logout { get; set; }
        public string? SessionId { get; set; }
        [NotMapped]
        public string? Token { get; set; }
    }
}
