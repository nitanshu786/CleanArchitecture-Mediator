using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiddlewareProject.Command;
using MiddlewareProject.ConfigureJWT;
using MiddlewareProject.Model;

namespace MiddlewareProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterApi : ControllerBase
    {
        private readonly IMediator _mediator;

        public RegisterApi(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public IActionResult Register(Register register)
        {
            if(register!=null)
            {
                var create= _mediator.Send( new RegisterCommand(register) );
                if (create != null)
                    return Ok(create);
            }
            return BadRequest(ModelState);
        }
        [HttpPost("Login")]
        public IActionResult Login(LoginVM login)
        {
            if (login != null)
            {
                Task<ResponseVM> user = _mediator.Send(new LoginCommand(login));
                if (user != null)
                    return Ok(user);
            }
            return NotFound();  
        }
    }
}
