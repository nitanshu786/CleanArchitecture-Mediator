using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using MiddlewareProject.DBContext;
using MiddlewareProject.Model;
using MiddlewareProject.ResponseTimeKey;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MiddlewareProject.Interface.IRepository.Repository
{
    public class RegisterRepo : IRegisterRepocs
    {
        //private readonly Dictionary<string, string> ActiveSession = new Dictionary<string, string>();
        private readonly ApplicationDbContext _context;
        private readonly JwtToken _jwtToken;
        private readonly HttpContext httpContext;

        public RegisterRepo(ApplicationDbContext context, IOptions<JwtToken> options, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _jwtToken = options.Value;
            httpContext = httpContextAccessor.HttpContext;

        }



        public bool IsUniqueUser(string email)
        {
            var value = _context.Registers.FirstOrDefault(s => s.Email == email);
            if (value != null)
            {
                return true;
            }
            return false;
        }

        public ResponseVM? Login(string Email, string Passward)
        {
            Register? value =  _context.Registers.FirstOrDefault(s => s.Email == Email && s.Pasword == Passward);
            if (value != null)
            {
               string sessionId = Guid.NewGuid().ToString();
                bool find = GetSessionIdByUsername(value.Email, sessionId);
                if (!find)
                {
                    LoginUsers loginUsers = new LoginUsers()
                    {
                        UserEmail = Email,
                        SessionId = sessionId,

                    };
                    _context.Users.Add(loginUsers);
                    _context.SaveChanges();
                }
                LoginVM vm = new LoginVM
                {
                    Email = Email,
                    Password = Passward,
                    Role = value.Role,
                 };
                Stopwatch tokenWatch = new Stopwatch();
                tokenWatch.Start();
                ResponseVM token = GenerateToken(vm, sessionId,  value.Id);
                tokenWatch.Stop();
                double tokenGenerationTime = tokenWatch.Elapsed.TotalMilliseconds;
                token.TokenCreationTime = tokenGenerationTime;  
                return token;       
                

            }

            return null;

        }

        public ResponseVM GenerateToken(LoginVM loginVM, string session, int id)
        {
            if (loginVM != null && session != null)
            {
                string loginVMData = JsonConvert.SerializeObject(loginVM);
                ClaimsIdentity identity = new ClaimsIdentity(new[]
                {
                  new Claim("Session_id", session.ToString()),
                  new Claim( "UserId", id.ToString()),
                  new Claim(ClaimTypes.Role,loginVM.Role.ToString())
                  //new Claim(ClaimTypes.Email, session.ToString())
                });

                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                byte[] key = Encoding.ASCII.GetBytes(_jwtToken.Secret);
                SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = identity,
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
                };
                SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
                loginVM.Token = tokenHandler.WriteToken(token);
                ResponseVM login = new ResponseVM
                {
                    Email = loginVM.Email,
                    Token = loginVM.Token,
                };
              
               
                return login;
            }
            return null;

        }

       

        public Register? Registers(Register register)
        {
            if (register != null)
            {
                bool find = IsUniqueUser(email: register.Email);
                if (!find)
                {
                    _context.Registers.Add(register);
                    _context.SaveChanges();
                    return register;
                }
            }
            return null;
        }

        private bool GetSessionIdByUsername(string Email, string sessionid)
        {

            LoginUsers? find = _context.Users.FirstOrDefault(x => x.UserEmail == Email);
            if (find != null)
            {
                find.SessionId = sessionid;
                _context.Users.Update(find);    
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
