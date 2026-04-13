using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizRepositoryClassLibrary.Dtos
{
    public class QuestionDto
    {
        public int Id { get; set; }

        public string QuestionText { get; set; } = null!;
    }
}
