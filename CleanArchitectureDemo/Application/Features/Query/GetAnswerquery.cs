using Application.Interface.IRepository;
using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Query
{
    public class GetAnswerquery : IRequest<IEnumerable<Quizquestions>>
    {
    }
    public class GetAnswerHandller : IRequestHandler<GetAnswerquery, IEnumerable<Quizquestions>>
    {
        private readonly IQuizRepo _quizRepo;

        public GetAnswerHandller(IQuizRepo quizRepo)
        {
            _quizRepo = quizRepo;
        }

        public async Task<IEnumerable<Quizquestions>> Handle(GetAnswerquery request, CancellationToken cancellationToken)
        {
            return _quizRepo.GetAllQuestionAnswer();
        }


    }
}
