using Application.DTO;
using Application.Features.Command;
using AutoMapper;
using Domain.Entity;
using Google.Apis.Auth;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterAPI : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly Appsettings _appsettings;

        public RegisterAPI(IMediator mediator, IOptions<Appsettings> appsettings)
        {
            _mediator = mediator;
            _appsettings = appsettings.Value;

        }

        [HttpPost]
        public async Task<IActionResult> Registers([FromBody] Register register)
        {
            if (register != null)
            {
                var create = await _mediator.Send(new CreateRegisterCommand(register));
                if (create == null)
                    return BadRequest("Failed to create register");
                else
                    return Ok(create);
            }
            return NotFound();
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginVM login)
        {
            if (login != null)
            {
                var data = await _mediator.Send(new LoginUserCommand(login));
                if (data == null)
                    return NotFound();
                return Ok(data);
            }
            return BadRequest();
        }

        [HttpPost("LoginWithGoogle")]
        public async Task<IActionResult> LoginWithGoogle([FromBody] string credential)
        {
            if (credential != null)
            {
                var settings = new GoogleJsonWebSignature.ValidationSettings()
                {
                    Audience = new List<string> { this._appsettings.GoogleClientId }
                };

                var payload = GoogleJsonWebSignature.ValidateAsync(credential, settings).Result;
                ExternalUser externalUser = new ExternalUser()
                {
                    UserId = payload.Subject,
                    Email = payload.Email,
                    Provider = payload.Issuer,
                    Name = payload.Name,
                };

                var token = await _mediator.Send(new GoogleCommand(externalUser));
                if (token != null)
                    return Ok(token);
                else
                    return NotFound();
            }
            else
                return BadRequest();
        }

       
    }
}
