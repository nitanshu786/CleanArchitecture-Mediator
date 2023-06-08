using MadiatorPattern.CommandQuery;
using MadiatorPattern.Model;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadiatorPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Student>> GetAllStudentList()
        {
            var list = await _mediator.Send(new GetStudentQuery());
            return list;
        }

        [HttpGet("{id}")]
        public async Task<Student> GetStudentById(int id)
        {
            if(id!=0)
            {
                var ID = await _mediator.Send(new GetStudentQueryId(id));
                return ID;
            }
            return null;
        }

        [HttpPost]
        public async Task<Student> CreateStudent(Student student)
        {
            if(student!=null)
            {
                var create = await _mediator.Send(new CreateCommand(student));
                return create;
            }
            return null;
        }

        [HttpPut]
        public async Task<Student> UpdateStudent(Student student)
        {
            if(student!=null)
            {
                var update = await _mediator.Send(new UpdateCommand(student));
                return update;
            }
            return null;
        }

        [HttpDelete("{id}")]
        public async Task<int> StudentDelete(int id)
        {
            if(id!=0)
            {
                return await _mediator.Send(new DeleteCommand() { Id = id });
            }
            return 0;
        }
    }
}
