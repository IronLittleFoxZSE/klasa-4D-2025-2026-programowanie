using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMvvmCalculatorMauiApp
{
    internal class MainViewModel : BindableObject
    {
        public string FirstStrNumber { get; set; }
        public string SecondStrNumber { get; set; }

        private string result;
        public string Result
        {
            get { return result; }
            set { result = value; OnPropertyChanged(); }
        }

        private Command calcCommand;
        public Command CalcCommand
        {
            get
            {
                /*if (calcCommand == null)
                    calcCommand = new Command(Calc);*/

                if (calcCommand == null)
                    calcCommand = new Command(
                        () =>
                        {
                            if (!int.TryParse(FirstStrNumber, out int firstNumber)
                                || !int.TryParse(SecondStrNumber, out int secondNumber))
                                return;

                            int sum = firstNumber + secondNumber;

                            Result = $"Wynik to {sum}";
                        }
                        );
                return calcCommand;
            }
            //set { calcCommand = value; }
        }

        public MainViewModel()
        {
            //CalcCommand = new Command(Calc);
        }


        /*
        private void Calc()
        {
            if (!int.TryParse(FirstStrNumber, out int firstNumber)
                || !int.TryParse(SecondStrNumber, out int secondNumber))
                return;

            int sum = firstNumber + secondNumber;

            Result = $"Wynik to {sum}";
        }
        */
    }
}
