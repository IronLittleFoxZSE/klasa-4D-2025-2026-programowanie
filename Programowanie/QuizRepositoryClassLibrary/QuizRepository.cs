using QuizRepositoryClassLibrary.Dtos;
using QuizRepositoryClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizRepositoryClassLibrary
{
    public class QuizRepository
    {
        private QuizDBContext context;

        public QuizRepository()
        {
            context = new QuizDBContext();
        }

        public QuestionDto? GetNextQuestion(int? id)
        {
            Question? question = context.Questions.OrderBy(q => q.Id).Where(q => id == null || q.Id > id).FirstOrDefault();
            if (question == null)
                return null;
            return new QuestionDto() { Id = question.Id, QuestionText = question.QuestionText };
        }

        public IEnumerable<AnswerDto> GetAnswers(int questionId)
        {
            return context.Answers.Where(a => a.QuestionId == questionId).OrderBy(a => a.Id).Select(a => new AnswerDto() { Id = a.Id, AnswerText = a.AnswerText, IsCorrect = a.IsCorrect });
        }
    }
}
