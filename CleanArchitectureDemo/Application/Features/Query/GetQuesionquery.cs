using Application.Interface.IRepository;
using Application.VmModel;
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
    public class GetQuesionquery : IRequest<IEnumerable<QuestionVM>>
    {
    }

    public class GetQuesionHandller : IRequestHandler<GetQuesionquery, IEnumerable<QuestionVM>>
    {
        private readonly IQuizRepo _quizRepo;

        public GetQuesionHandller(IQuizRepo quizRepo)
        {
            _quizRepo = quizRepo;
        }

        public async Task<IEnumerable<QuestionVM>> Handle(GetQuesionquery request, CancellationToken cancellationToken)
        {
            var data = _quizRepo.GetAllQuestion();
            if (data != null)
                return data;
            return null;
        }


    }
}
