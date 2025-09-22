namespace SimpleBindingCalculatorMauiApp
{
    public partial class MainPage : ContentPage
    {
        public string FirstStrNumber { get; set; }
        public string SecondStrNumber { get; set; }

        private string result;
        public string Result
        {
            get { return result; }
            set { result = value; OnPropertyChanged(); }
        }

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (!int.TryParse(FirstStrNumber, out int firstNumber)
                || !int.TryParse(SecondStrNumber, out int secondNumber))
                return;

            int sum = firstNumber + secondNumber;

            Result = $"Wynik to {sum}";
        }
    }
}
