using Application.Features.Command;
using Application.Features.Query;
using Application.VmModel;
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
    public class QuizController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QuizController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("GetQuestion")]
        public async Task<IActionResult> GetAllQuestion()
        {
            var que = await _mediator.Send(new GetQuesionquery());
            if (que != null)
                return Ok(que);
            return BadRequest("No Data Found");
        }

        [HttpGet("GetAnswer")]
        public async Task<IActionResult> GetAllQuestionAnswer()
        {
            var data = await _mediator.Send(new GetAnswerquery());
            if (data != null)
                return Ok(data);
            return BadRequest("No Data Found");
        }
    

        [HttpPost("question")]
        public async Task<IActionResult> CreateQuestion([FromBody]Quizquestions quizquestions )
        {
            if (quizquestions != null)
            {
                var data = await _mediator.Send(new CreateQuestionCommand(quizquestions));
                if (data != null)
                    return Ok(data);
                return BadRequest("No Data Found");
            }
            return BadRequest("Column is required");
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            if(id!=0)
            {
                var dell= await _mediator.Send(new DeleteQuestionCommand() { Id=id});
                if (dell != 0)
                    return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateQuestion([FromBody] Quizquestions quizquestions)
        {
            if (quizquestions != null)
            {
                var upd = await _mediator.Send(new UpdateQuestionCommand(quizquestions));
                if (upd != null)
                    return Ok(upd);
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnswer([FromBody] UserSelectedAnswer userSelectedAnswer)
        {
            if (userSelectedAnswer != null)
            {
                var data = await _mediator.Send(new CreateUserSelectCommand(userSelectedAnswer));
                if (data != null)
                    return Ok(data);
                return BadRequest("No Data Found");
            }
            return BadRequest("Column is required");
        }
        //[HttpGet("GetAnswerbyquestion")]
        //public async Task<IActionResult> GetAllAnswerByQuestion()
        //{
        //    var que = await _mediator.Send(new GetAnswerByQuestion());
        //    if (que != null)
        //        return Ok(que);
        //    return BadRequest("No Data Found");
        //}
    }
}
