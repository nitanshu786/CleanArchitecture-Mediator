using Application.Interface.IRepository;
using Application.VmModel;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.Repository
{
    public class QuizRepo : IQuizRepo
    {

        private readonly IApplicatinDbContext _Context;

        public QuizRepo(IApplicatinDbContext context)
        {
            _Context = context;
        }

        public Quizquestions CreateQuiz(Quizquestions quizquestions)
        {
            if (quizquestions != null)
            {
                var create = _Context.Quizquestions.Add(quizquestions);
                _Context.SaveChanges();
                return create.Entity;
            }
            return null;
        }

        public async Task<UserSelectedAnswer> CreateUserAnswer(UserSelectedAnswer userSelectedAnswer)
        {
            if (userSelectedAnswer != null)
            {
                var Answer = _Context.UserSelectedAnswers.Add(userSelectedAnswer);
                await _Context.SaveChangesAsync();
                return Answer.Entity;
            }
            return null;
        }
        public IEnumerable<Quizquestions> GetAllQuestionAnswer()
        {
            return _Context.Quizquestions.ToList();
        }

        //public ICollection<QuizAnswer> GetAllAnswerByQuestion()
        //{
        //    var innerdata = _Context.QuizAnswers.Include(s => s.Quizquestions).ToList();
        //    return innerdata;
        //}

        public IEnumerable<QuestionVM> GetAllQuestion()
        {
            var data = _Context.Quizquestions.Select(n => new QuestionVM
            {
                Id = n.Id,
                Question = n.Question,
                QuestionNumber = n.QuestionNumber,
                Option1 = n.Option1,
                Option2 = n.Option2,
                Option3 = n.Option3,
                Option4 = n.Option4
            }).ToList();
            return data;
        }

        public async Task<List<UserSelectedAnswer>> GetAllUserSeletedAnswer()
        {
            return await _Context.UserSelectedAnswers.ToListAsync();
        }

        public async Task<int> GetByID(int Id)
        {
            var find = await _Context.Quizquestions.FindAsync(Id);
            if (find != null)
                return find.Id;
            return 0;
        }

        public async Task<int> QuizDelete(int Id)
        {
            var id = await _Context.Quizquestions.FindAsync(Id);
            if (id != null)
            {
                _Context.Quizquestions.Remove(id);
                return await _Context.SaveChanges();
            }
            return 0;
        }

        public async Task<Quizquestions> QuizUpdate(Quizquestions quizquestions)
        {
            if (quizquestions != null)
            {
                var upd = _Context.Quizquestions.Update(quizquestions);
                await _Context.SaveChangesAsync();
                return upd.Entity;
            }
            return null;
        }
    }
}
