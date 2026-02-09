using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMvvmCalculatorMauiApp.Model
{
    public interface IArytmeticService
    {
        public string Calculate(string firstStrNumber, string secondStrNumber);
    }
}
