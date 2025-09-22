namespace SimpleCalculatorMauiApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (!int.TryParse(firstNumberEntry.Text, out int firstNumber)
                || !int.TryParse(secondNumberEntry.Text, out int secondNumber)) 
                return;

            int result = firstNumber + secondNumber;

            resultLabel.Text = $"Wynik to {result}";
        }
    }
}
