
namespace DayPlannerMauiApp.ViewModelModels;

public class Plannerday : BindableObject
{
    private int id;
    public int Id
    {
        get => id;
        set { id = value; OnPropertyChanged(); }
    }

    private int day;
    public int Day
    {
        get => day;
        set { day = value; OnPropertyChanged(); }
    }

    private int month;
    public int Month
    {
        get => month;
        set { month = value; OnPropertyChanged(); }
    }

    private int year;
    public int Year
    {
        get => year;
        set { year = value; OnPropertyChanged(); }
    }
}
