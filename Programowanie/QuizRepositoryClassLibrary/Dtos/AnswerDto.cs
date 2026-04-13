using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizRepositoryClassLibrary.Dtos
{
    public class AnswerDto
    {
        public int Id { get; set; }

        public string AnswerText { get; set; } = null!;

        public bool IsCorrect { get; set; }
    }
}
