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
    public class CreateQuestionCommand : IRequest<Quizquestions>
    {
        public CreateQuestionCommand(Quizquestions quizquestions)
        {
            Question = quizquestions.Question;
            Option1 = quizquestions.Option1;
            Option2 = quizquestions.Option2;
            Option3 = quizquestions.Option3;
            Option4 = quizquestions.Option4;
            CorrectAnswer = quizquestions.CorrectAnswer;
        }

        public string Question { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string CorrectAnswer { get; set; }
    }

    public class CreateQuestionHandller : IRequestHandler<CreateQuestionCommand, Quizquestions>
    {
        private readonly IQuizRepo _quizRepo;

        public CreateQuestionHandller(IQuizRepo quizRepo)
        {
            _quizRepo = quizRepo;
        }

        public async Task<Quizquestions> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                Quizquestions quizquestions = new Quizquestions()
                {
                    Question = request.Question,
                    Option1 = request.Option1,
                    Option2 = request.Option2,
                    Option3 = request.Option3,
                    Option4 = request.Option4,
                    CorrectAnswer = request.CorrectAnswer,
                };
                var createnew = _quizRepo.CreateQuiz(quizquestions);
                return createnew;
            }
            return null;
        }
    }
}
