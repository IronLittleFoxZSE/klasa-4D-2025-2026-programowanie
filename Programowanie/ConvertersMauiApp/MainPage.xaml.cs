using ConvertersMauiApp.Converters;

namespace ConvertersMauiApp
{
    public partial class MainPage : ContentPage
    {
        private string grade;

        public string Grade
        {
            get { return grade; }
            set
            {
                grade = value;
                TextGrade = grade switch
                {
                    "1" => "Niedostateczny",
                    "2" => "Dopuszczający",
                    "3" => "Dostateczny",
                    "4" => "Dobry",
                    "5" => "Bardzo dobry",
                    "6" => "Celujący",
                    _ => "Nieznana ocena",
                };
            }
        }

        private string textGrade;

        public string TextGrade
        {
            get { return textGrade; }
            set { textGrade = value; OnPropertyChanged(); }
        }

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
