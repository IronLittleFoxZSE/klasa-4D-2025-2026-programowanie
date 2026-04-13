using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DayPlannerRepositoryClassLibrary.Models;

public partial class Plan
{
    [Key]
    public int Id { get; set; }

    public string Text { get; set; } = null!;

    public int PlannerdayId { get; set; }

    public virtual Plannerday Plannerday { get; set; } = null!;
}

