using MiddlewareProject.ConfigureJWT;
using System.Text.Json.Serialization;

namespace MiddlewareProject.Model
{


    public class LoginVM
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        [JsonIgnore]
        public string? Token { get; set; }
        [JsonIgnore]
        public string? Role { get; set; }
       
       
    
    }
}
