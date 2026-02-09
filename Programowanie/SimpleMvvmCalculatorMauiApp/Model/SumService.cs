using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMvvmCalculatorMauiApp.Model
{
    class SumService: IArytmeticService
    {
        public virtual string Calculate(string firstStrNumber, string secondStrNumber)
        {
            if (!int.TryParse(firstStrNumber, out int firstNumber)
                               || !int.TryParse(secondStrNumber, out int secondNumber))
                return "";

            int sum = firstNumber + secondNumber;

            return $"Wynik to {sum}";
        }
    }
}
