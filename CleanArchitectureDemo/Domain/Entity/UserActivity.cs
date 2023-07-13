using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{

    public class UserActivity
    {
        [Key]
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string UserName { get; set; }
        public string Url { get; set; }
        public string Data { get; set; }
        public string IpAddress { get; set; }
        public DateTime Activity { get; set; } = DateTime.Now;
    }
}
