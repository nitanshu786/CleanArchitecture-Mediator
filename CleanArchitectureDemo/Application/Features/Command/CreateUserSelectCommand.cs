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
    public class CreateUserSelectCommand : IRequest<UserSelectedAnswer>
    {

        public CreateUserSelectCommand(UserSelectedAnswer userSelectedAnswer)
        {
            SelectAnswer = userSelectedAnswer.SelectAnswer;
            UserId = userSelectedAnswer.UserId;
            QuestionId = userSelectedAnswer.QuestionId;
        }

        public string SelectAnswer { get; set; }
        public int UserId { get; set; }
        public int QuestionId { get; set; }

    }

    public class CreateUserHandller : IRequestHandler<CreateUserSelectCommand, UserSelectedAnswer>
    {

        private readonly IQuizRepo _quizRepo;

        public CreateUserHandller(IQuizRepo quizRepo)
        {
            _quizRepo = quizRepo;
        }

        public Task<UserSelectedAnswer> Handle(CreateUserSelectCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                UserSelectedAnswer userSelectedAnswer = new UserSelectedAnswer()
                {
                    SelectAnswer = request.SelectAnswer,
                    UserId = request.UserId,
                    QuestionId = request.QuestionId,

                };
                var create = _quizRepo.CreateUserAnswer(userSelectedAnswer);
                if (create != null)
                    return create;
            }
            return null;
        }
    }
}
