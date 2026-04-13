using DayPlannerMauiApp.ViewModelModels;
using DayPlannerRepositoryClassLibrary;
using DayPlannerRepositoryClassLibrary.Dtos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayPlannerMauiApp
{
    public class MainViewModel : BindableObject
    {
        #region Lista zadań

        private ObservableCollection<int> plannerYearFilter;
        public ObservableCollection<int> PlannerYearFilter
        {
            get { return plannerYearFilter; }
            set 
            { 
                plannerYearFilter = value; 
                OnPropertyChanged();
            }
        }

        private int selectedYearFilter;
        public int SelectedYearFilter
        {
            get { return selectedYearFilter; }
            set 
            { 
                selectedYearFilter = value; 
                OnPropertyChanged();
                ChangeMonthFilter();
            }
        }

        private ObservableCollection<int> plannerMonthFilter;
        public ObservableCollection<int> PlannerMonthFilter
        {
            get { return plannerMonthFilter; }
            set 
            { 
                plannerMonthFilter = value; 
                OnPropertyChanged();
            }
        }

        private int selectedMonthFilter;
        public int SelectedMonthFilter
        {
            get { return selectedMonthFilter; }
            set 
            { 
                selectedMonthFilter = value; 
                OnPropertyChanged();
                ChangeDayFilter();
            }
        }

        private ObservableCollection<int> plannerDayFilter;
        public ObservableCollection<int> PlannerDayFilter
        {
            get { return plannerDayFilter; }
            set { plannerDayFilter = value; OnPropertyChanged(); }
        }

        private int selectedDayFilter;
        public int SelectedDayFilter
        {
            get { return selectedDayFilter; }
            set { selectedDayFilter = value; OnPropertyChanged(); }
        }


        private ObservableCollection<Plan> plans;
        public ObservableCollection<Plan> Plans
        {
            get { return plans; }
            set { plans = value; OnPropertyChanged(); }
        }

        private Command getPlansCommand;
        public Command GetPlansCommand
        {
            get 
            { 
                if (getPlansCommand == null)
                    getPlansCommand = new Command(
                        ()=>
                        {
                            Plans.Clear();
                            foreach (PlanDto plan in dayPlannerRepository.GetPlans(selectedDayFilter, selectedMonthFilter, selectedYearFilter))
                                Plans.Add(new Plan() { Id = plan.Id, Text = plan.Text, DeleteCommand = DeletePlanCommand });
                        }
                        );
                return getPlansCommand; 
            }
        }

        private Command deletePlanCommand;
        public Command DeletePlanCommand
        {
            get
            {
                if (deletePlanCommand == null)
                    deletePlanCommand = new Command<Plan>(
                        (plan) =>
                        {
                            dayPlannerRepository.DeletePlan(plan.Id);
                            Plans.Remove(plan);
                        }
                        );
                return deletePlanCommand;
            }
        }

        public ObservableCollection<int> NewDays { get; set; }

        private int selectedNewDay;
        public int SelectedNewDay
        {
            get { return selectedNewDay; }
            set
            {
                selectedNewDay = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<int> NewMonths { get; set; }

        private int selectedNewMonth;
        public int SelectedNewMonth
        {
            get { return selectedNewMonth; }
            set
            {
                selectedNewMonth = value;
                OnPropertyChanged();
                ChangeNewDay();
            }
        }

        public ObservableCollection<int> NewYears { get; set; }

        private int selectedNewYear;
        public int SelectedNewYear
        {
            get { return selectedNewYear; }
            set 
            { 
                selectedNewYear = value; 
                OnPropertyChanged();
                ChangeNewMonth();
            }
        }

        private string newPlanText;

        public string NewPlanText
        {
            get { return newPlanText; }
            set { newPlanText = value; OnPropertyChanged(); }
        }

        private Command addNewPlanCommand;
        public Command AddNewPlanCommand
        {
            get
            {
                if (addNewPlanCommand == null)
                    addNewPlanCommand = new Command(
                        () =>
                        {
                            dayPlannerRepository.AddNewPlan(selectedNewDay, selectedNewMonth, selectedNewYear, newPlanText);
                        }
                        );
                return addNewPlanCommand;
            }
        }


        #endregion

        #region Nowy plan

        #endregion

        private DayPlannerRepository dayPlannerRepository;
        public MainViewModel()
        {
            dayPlannerRepository = new DayPlannerRepository();

            Plans = new();

            PlannerDayFilter = new();
            PlannerMonthFilter = new();
            PlannerYearFilter = new ObservableCollection<int>();
            foreach (int year in dayPlannerRepository.GetPlannerYears())
                PlannerYearFilter.Add(year);
            SelectedYearFilter = PlannerYearFilter.FirstOrDefault();

            NewDays = new ObservableCollection<int>();
            NewMonths = new ObservableCollection<int>();
            NewYears = new ObservableCollection<int>();
            for (int year = DateTime.Now.Year; year < DateTime.Now.Year + 2; year++)
                NewYears.Add(year);


            SelectedNewYear = NewYears.First();
        }

        private void ChangeMonthFilter()
        {
            PlannerMonthFilter.Clear();
            foreach (int month in dayPlannerRepository.GetPlannerMonth(selectedYearFilter))
                PlannerMonthFilter.Add(month);
            SelectedMonthFilter = PlannerMonthFilter.FirstOrDefault();
        }

        private void ChangeDayFilter()
        {
            PlannerDayFilter.Clear();
            foreach (int month in dayPlannerRepository.GetPlannerDays(selectedYearFilter, selectedMonthFilter))
                PlannerDayFilter.Add(month);
            SelectedDayFilter = PlannerDayFilter.FirstOrDefault();
        }

        private void ChangeNewMonth()
        {
            NewMonths.Clear();
            foreach(int month in GetAvailableMonths(selectedNewYear))
                NewMonths.Add(month);
            SelectedNewMonth = NewMonths.First();
        }

        private void ChangeNewDay()
        {
            NewDays.Clear();
            foreach (int day in GetAvailableDays(selectedNewYear, selectedNewMonth))
                NewDays.Add(day);
            SelectedNewDay = NewDays.First();
        }

        private IEnumerable<int> GetAvailableMonths(int year)
        {
            int currentYear = DateTime.Now.Year;
            int currentMonth = DateTime.Now.Month;

            if (year == currentYear)
            {
                return Enumerable.Range(currentMonth, 12 - currentMonth + 1);
            }
            else
            {
                return Enumerable.Range(1, 12);
            }
        }


        private IEnumerable<int> GetAvailableDays(int year, int month)
        {
            int currentYear = DateTime.Now.Year;
            int currentMonth = DateTime.Now.Month;
            int currentDay = DateTime.Now.Day;

            int daysInMonth = DateTime.DaysInMonth(year, month);

            // Jeśli bieżący rok i miesiąc → zwracamy dni od dzisiejszego do końca miesiąca
            if (year == currentYear && month == currentMonth)
            {
                return Enumerable.Range(currentDay, daysInMonth - currentDay + 1);
            }

            // W innym przypadku → pełny zakres
            return Enumerable.Range(1, daysInMonth);
        }


    }
}
