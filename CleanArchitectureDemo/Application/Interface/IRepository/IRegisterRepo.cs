using Application.DTO;
using Application.VmModel;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.IRepository
{
    public interface IRegisterRepo
    {
        bool IsUniqueUser(string UserName, string Email);
        Task<LoginReturn> Login(string Email, string Password);
        Task<Register> Registers(Register register);
        Task<LoginReturn> GenreateToken(Register register, string session);
        ExternalUser FindUser(ExternalUser externalUser);
        Task<ExternalUser> GoogleLogin(ExternalUser externalUser);
        ExternalUser GoogleRegister(ExternalUser externalUser);
        //bool ExtractEmailFromToken(string jwtToken);

        //bool RemoveToken(string Email);

    }
}
