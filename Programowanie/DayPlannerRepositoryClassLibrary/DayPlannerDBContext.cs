using System;
using System.Collections.Generic;
using DayPlannerRepositoryClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace DayPlannerRepositoryClassLibrary;

public partial class DayPlannerDBContext : DbContext
{
    public DayPlannerDBContext()
    {
    }

    public DayPlannerDBContext(DbContextOptions<DayPlannerDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Plan> Plans { get; set; }

    public virtual DbSet<Plannerday> Plannerdays { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost;database=dayplanner4d;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));

}
