using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class LoginUsers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        public string UserEmail { get; set; }
        public DateTime LoginUser { get; set; }
        public DateTime Logout { get; set; }
        public string SessionId { get; set; }
        [NotMapped]
        public string Token { get; set; }
    }
}
