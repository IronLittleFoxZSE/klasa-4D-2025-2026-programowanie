using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuizRepositoryClassLibrary.Models;

[Table("answers")]
[Index("QuestionId", Name = "question_id")]
public partial class Answer
{
    [Key]
    [Column("id", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("answer_text")]
    [StringLength(500)]
    public string AnswerText { get; set; } = null!;

    [Column("is_correct")]
    public bool IsCorrect { get; set; }

    [Column("question_id", TypeName = "int(11)")]
    public int QuestionId { get; set; }

    [ForeignKey("QuestionId")]
    [InverseProperty("Answers")]
    public virtual Question Question { get; set; } = null!;
}
