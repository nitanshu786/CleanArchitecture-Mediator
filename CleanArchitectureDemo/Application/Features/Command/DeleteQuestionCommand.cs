using Application.Interface.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Command
{
    public class DeleteQuestionCommand : IRequest<int>
    {
        public int Id { get; set; }
    }

    public class DeleteQuestionHandller : IRequestHandler<DeleteQuestionCommand, int>
    {
        private readonly IQuizRepo _quizRepo;

        public DeleteQuestionHandller(IQuizRepo quizRepo)
        {
            _quizRepo = quizRepo;
        }

        public async Task<int> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {
            return await _quizRepo.QuizDelete(request.Id);
        }
    }
}
