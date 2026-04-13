using DayPlannerRepositoryClassLibrary.Dtos;
using DayPlannerRepositoryClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayPlannerRepositoryClassLibrary
{
    public class DayPlannerRepository
    {
        private DayPlannerDBContext context;

        public DayPlannerRepository()
        {
            context = new DayPlannerDBContext();
        }

        public List<PlanDto> GetPlans(int day, int month, int year)
        {
            return context
                .Plans
                .Include(p => p.Plannerday)
                .Where(p => p.Plannerday.Day == day
                           && p.Plannerday.Month == month
                           && p.Plannerday.Year == year)
                .Select(p => new PlanDto() { Id = p.Id, Text = p.Text })
                .ToList();
        }

        public List<int> GetPlannerYears()
        {
            return context.Plannerdays.Select(pd => pd.Year).Distinct().ToList();
        }

        public List<int> GetPlannerMonth(int year)
        {
            return context.Plannerdays.Where(pd => pd.Year == year).Select(pd => pd.Month).Distinct().ToList();
        }

        public List<int> GetPlannerDays(int year, int month)
        {
            return context
                .Plannerdays
                .Where(pd => pd.Year == year
                             && pd.Month == month)
                .Select(pd => pd.Day)
                .Distinct()
                .ToList();
        }

        public PlannerdayDto? GetPlannerDay(int day, int month, int year)
        {
            Plannerday? plannerday = context
                .Plannerdays
                .Where(pd => pd.Day == day
                              && pd.Month == month
                              && pd.Year == year)
                .FirstOrDefault();

            return plannerday == null ? null : new PlannerdayDto() { Id = plannerday.Id, Day = plannerday.Day, Month = plannerday.Month, Year = plannerday.Year };
        }

        public PlannerdayDto CreatePlannerDay(int day, int month, int year)
        {
            PlannerdayDto? plannerdayDto;
            if ((plannerdayDto = GetPlannerDay(day, month, year)) == null)
            {
                Plannerday plannerday = new Plannerday() { Day = day, Month = month, Year = year };
                context.Plannerdays.Add(plannerday);
                plannerdayDto = new PlannerdayDto() { Id = plannerday.Id, Day = plannerday.Day, Month = plannerday.Month, Year = plannerday.Year };
            }

            return plannerdayDto;
        }

        public void DeletePlan(int id)
        {
            Plan? plantoDelete = context.Plans.FirstOrDefault(p=> p.Id == id);
            if (plantoDelete != null)
            {
                context.Plans.Remove(plantoDelete);
                context.SaveChanges();
            }
        }

        public void AddNewPlan(int day, int month, int year, string text)
        {
            Plannerday? plannerday = context.Plannerdays.FirstOrDefault(pd => pd.Day == day && pd.Month==month && pd.Year==year);

            if (plannerday == null)
                plannerday = AddNewPlannerDay(day, month, year);

            Plan plan = new Plan()
            {
                Text = text,
                PlannerdayId = plannerday.Id
            };
            context.Plans.Add(plan);
            context.SaveChanges();
        }

        private Plannerday AddNewPlannerDay(int day, int month, int year)
        {
            Plannerday plannerday = new Plannerday()
            {
                Day = day,
                Month = month,
                Year = year
            };
            context.Plannerdays.Add(plannerday);
            context.SaveChanges();
            return plannerday;
        }
    }
}
