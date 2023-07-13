using Application.Features.Command;
using Application.Features.Query;
using Application.Interface.Repository;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentAPI : ControllerBase
    {
        private readonly IMediator _mediator;

       
      

        public StudentAPI(IMediator mediator)
        {
            _mediator = mediator;
           
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudentList()
        {
            StringValues authorizationHeaders;
            Request.Headers.TryGetValue("Authorization", out authorizationHeaders);
            string tokenValue = authorizationHeaders.FirstOrDefault()?.Split(" ").LastOrDefault();
            bool find = await _mediator.Send(new OneTimeLoginCommand() { Token = tokenValue });
            if (find)
            {
                var list = await _mediator.Send(new GetAllStudentQuery());
                return Ok(list);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            if (id != 0)
            {
                var ID = await _mediator.Send(new GetStudentById(id));
                if (id == 0)
                    return NotFound();
                return Ok(ID);
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(Student student)
        {
            if (student != null)
            {
                var create = await _mediator.Send(new CreateStudentCommand(student));
                if (create == null)
                    return NotFound();
                return Ok(create);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudent(Student student)
        {
            if (student != null)
            {
                var update = await _mediator.Send(new UpdateStudentCommand(student));
                if (update == null)
                    return NotFound();
                return Ok(update);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> StudentDelete(int id)
        {
            if (id != 0)
            {
              var dell=  await _mediator.Send(new DeleteStudentCommand() { Id = id });
                if (dell == 0)
                    return NotFound();
                return Ok(dell);
            }
            return BadRequest();
        }
    }
}
