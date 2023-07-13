using Application.Interface.IRepository;
using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Command
{
    public class UpdateQuestionCommand : IRequest<Quizquestions>
    {
        public UpdateQuestionCommand(Quizquestions quizquestions)
        {
            Id = quizquestions.Id;
            Question = quizquestions.Question;
            Option1 = quizquestions.Option1;
            Option2 = quizquestions.Option2;
            Option3 = quizquestions.Option3;
            Option4 = quizquestions.Option4;
            CorrectAnswer = quizquestions.CorrectAnswer;

        }
        public int Id { get; set; }
        public string Question { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string CorrectAnswer { get; set; }
    }


    public class UpdateQuestionHandller : IRequestHandler<UpdateQuestionCommand, Quizquestions>
    {
        private readonly IQuizRepo _quizRepo;

        public UpdateQuestionHandller(IQuizRepo quizRepo)
        {
            _quizRepo = quizRepo;
        }

        public Task<Quizquestions> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                Quizquestions quizquestions = new Quizquestions()
                {
                    Id = request.Id,
                    Question = request.Question,
                    Option1 = request.Option1,
                    Option2 = request.Option2,
                    Option3 = request.Option3,
                    Option4 = request.Option4,
                    CorrectAnswer = request.CorrectAnswer
                };
                var update = _quizRepo.QuizUpdate(quizquestions);
                if (update != null)
                    return update;
            }
            return null;
        }
    }


}
