using SimpleMvvmCalculatorMauiApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMvvmCalculatorMauiApp
{
    internal class MainViewModel : BindableObject
    {
        public string FirstStrNumber 
        {
            get { return dataRepository.firstStrNumber; }
            set { dataRepository.firstStrNumber = value; } 
        }

        public string SecondStrNumber
        {
            get { return dataRepository.secondStrNumber; }
            set { dataRepository.secondStrNumber = value; }
        }

        public string Result
        {
            get { return dataRepository.result; }
            set { dataRepository.result = value; OnPropertyChanged(); }
        }

        private bool withServises;
        public bool WithServises
        {
            get { return withServises; }
            set 
            { 
                withServises = value;
                if (withServises)
                    service = new DivService();
                else
                    service = new SumService();
                OnPropertyChanged(); 
            }
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
                            /*if (!int.TryParse(FirstStrNumber, out int firstNumber)
                                || !int.TryParse(SecondStrNumber, out int secondNumber))
                                return;

                            int sum = firstNumber + secondNumber;

                            Result = $"Wynik to {sum}";*/

                            Result = service.Calculate(FirstStrNumber, SecondStrNumber);
                        }
                        );
                return calcCommand;
            }
            //set { calcCommand = value; }
        }

        private IArytmeticService service;
        private DataRepository dataRepository;

        public MainViewModel()
        {
            //CalcCommand = new Command(Calc);
            //service = new SumService();
            //service = new DivService();
            WithServises = true;
            dataRepository = new DataRepository();
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
