using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMvvmCalculatorMauiApp.Model
{
    class DivService: IArytmeticService
    {
        public virtual string Calculate(string firstStrNumber, string secondStrNumber)
        {
            if (!int.TryParse(firstStrNumber, out int firstNumber)
                               || !int.TryParse(secondStrNumber, out int secondNumber))
                return "";

            if (secondNumber == 0)
                return "Dzielenie przez zero!!!!";

            int div = firstNumber / secondNumber;

            return $"Wynik to {div}";
        }
    }
}
