using Application.DTO;
using Application.Interface.IRepository;
using Application.VmModel;
using Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.Repository
{
    public class RegisterRepo : IRegisterRepo
    {
        private readonly Dictionary<string, string> ActiveSessions = new Dictionary<string, string>();
        private readonly IApplicatinDbContext _context;
        private readonly JwtToken _jwtToken;


        public RegisterRepo(IApplicatinDbContext context, IOptions<JwtToken> jwtToken)
        {
            _context = context;
            _jwtToken = jwtToken.Value;
        }





        public bool IsUniqueUser(string UserName, string Email)
        {
            var find = _context.Registers.FirstOrDefault(s => s.Email == Email && s.UserName == UserName);
            if (find != null)
                return true;
            else
                return false;
        }

        public Task<LoginReturn> Login(string Email, string Password)
        {
            var Auth = _context.Registers.FirstOrDefault(s => s.Email == Email && s.Password == Password);
            if (Auth != null)
            {
                var existingSessionId = GetSessionIdByUsername(Email);
                if (!existingSessionId)
                {
                    string sessionId = Guid.NewGuid().ToString();
                    ActiveSessions[sessionId] = Auth.Email;
                    LoginUsers loginUsers = new LoginUsers()
                    {
                        SessionId = sessionId,
                        UserEmail = Email,
                        LoginUser = DateTime.UtcNow,
                    };

                    _context.LoginUsers.Add(loginUsers);
                    _context.SaveChanges();
                    var jwt = GenreateToken(Auth, sessionId);
                    return jwt;
                }
                return null;


            }
            return null;
        }
        public async Task<Register> Registers(Register register)
        {
            if (register != null)
            {
                var find = IsUniqueUser(register.UserName, register.Email);
                if (!find)
                {
                    Register register1 = new Register()
                    {
                        Email = register.Email,
                        UserName = register.UserName,
                        Password = register.Password,
                        Role = "User",
                    };
                    var Data = await _context.Registers.AddAsync(register1);
                    await _context.SaveChangesAsync();
                    return Data.Entity;
                }
                else
                    return null;
            }
            return null;
        }

        public async Task<LoginReturn> GenreateToken(Register register, string session)
        {
            if (register != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_jwtToken.Secret);
                var tokenDescritor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, register.Id.ToString()),
                    new Claim(ClaimTypes.Email, session.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescritor);
                register.Token = tokenHandler.WriteToken(token);

                LoginReturn Tokens = new LoginReturn()
                {
                    Id = register.Id,
                    Token = register.Token,
                    Email = register.UserName,
                    Role = register.Role,
                };
                return Tokens;
            }
            return null;

        }

        public ExternalUser FindUser(ExternalUser externalUser)
        {
            var finduser = _context.ExternalUsers.FirstOrDefault(s => s.Email == externalUser.Email);
            if (finduser != null)
            {

                return finduser;
            }
            return null;
        }


        public Task<ExternalUser> GoogleLogin(ExternalUser externalUser)
        {
            if (externalUser != null)
            {
                var token = GenreateTokenGoogle(externalUser);
                return token;

            }
            return null;

        }

        public ExternalUser GoogleRegister(ExternalUser externalUser)
        {
            if (externalUser != null)
            {
                _context.ExternalUsers.Add(externalUser);
                _context.SaveChangesAsync();
                return externalUser;
            }
            return null;
        }

        public async Task<ExternalUser> GenreateTokenGoogle(ExternalUser externalUser)
        {
            if (externalUser != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_jwtToken.Secret);
                var tokenDescritor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, externalUser.Email.ToString())


                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescritor);
                externalUser.Token = tokenHandler.WriteToken(token);
                return await Task.FromResult(externalUser);
            }
            return null;

        }

        private bool GetSessionIdByUsername(string Email)
        {

            var find = _context.LoginUsers.FirstOrDefault(x => x.UserEmail == Email);
            if (find != null)
            {
                _context.LoginUsers.Remove(find);
                _context.SaveChanges();
            }
            return false;
        }

        private void InvalidateSession(string sessionId)
        {
            ActiveSessions.Remove(sessionId);

        }

    }
}
