using Application.Features.Command;
using Application.Features.Query;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPI : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentAPI(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Student>> GetAllStudentList()
        {
            var list = await _mediator.Send(new GetAllStudentQuery());
            return list;
        }

        [HttpGet("{id}")]
        public async Task<Student> GetStudentById(int id)
        {
            if (id != 0)
            {
                var ID = await _mediator.Send(new GetStudentById(id));
                return ID;
            }
            return null;
        }

        [HttpPost]
        public async Task<Student> CreateStudent(Student student)
        {
            if (student != null)
            {
                var create = await _mediator.Send(new CreateStudentCommand(student));
                return create;
            }
            return null;
        }

        [HttpPut]
        public async Task<Student> UpdateStudent(Student student)
        {
            if (student != null)
            {
                var update = await _mediator.Send(new UpdateStudentCommand(student));
                return update;
            }
            return null;
        }

        [HttpDelete("{id}")]
        public async Task<int> StudentDelete(int id)
        {
            if (id != 0)
            {
                return await _mediator.Send(new DeleteStudentCommand() { Id = id });
            }
            return 0;
        }
    }
}
