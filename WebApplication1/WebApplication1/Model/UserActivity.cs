using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MiddlewareProject.Model
{
    public class UserActivity
    {
        public int Id { get; set; }
        public string? User_Id { get; set; }
        public string? Url { get; set; }
        public string? Data { get; set; }
        public string? TraceId { get; set; }
        public string? IpAddress { get; set; }
        public DateTime Activity { get; set; } = DateTime.Now;
    }
}
