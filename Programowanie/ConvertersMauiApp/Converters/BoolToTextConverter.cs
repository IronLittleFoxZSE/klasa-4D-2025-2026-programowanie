using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertersMauiApp.Converters
{
    class BoolToTextConverter : IValueConverter
    {
        public string TrueMessage { get; set; }
        public string FalseMessage { get; set; }


        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null
                || value is not bool)
                return Binding.DoNothing;

            bool isChecked = (bool)value;

            if (isChecked)
                return TrueMessage;
            else
                return FalseMessage;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
