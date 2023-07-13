using Application.VmModel;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.IRepository
{
    public interface IQuizRepo
    {
        IEnumerable<QuestionVM> GetAllQuestion();
        Quizquestions CreateQuiz(Quizquestions quizquestions);
        Task<int> GetByID(int Id);
        Task<Quizquestions> QuizUpdate(Quizquestions quizquestions);
        Task<int> QuizDelete(int Id);

        //Answer
        IEnumerable<Quizquestions> GetAllQuestionAnswer();
        // UserSelected

        Task<List<UserSelectedAnswer>> GetAllUserSeletedAnswer();
        Task<UserSelectedAnswer> CreateUserAnswer(UserSelectedAnswer userSelectedAnswer);
    }
}
