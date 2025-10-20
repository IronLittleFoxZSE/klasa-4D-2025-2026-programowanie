using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConvertersMauiApp.Converters
{
    public class GradeToTextGradeConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null
                || value is not string) 
                return null;

            string grade = (string)value;

            return grade switch
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

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
