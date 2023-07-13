using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using MiddlewareProject.Command;
using MiddlewareProject.Model;
using MiddlewareProject.Querys;

namespace MiddlewareProject.Controllers
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
           var list = await _mediator.Send(new GetAllStudentQuery());
            if(list!=null)
            return Ok(list);
            return NotFound();
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
    }
}
