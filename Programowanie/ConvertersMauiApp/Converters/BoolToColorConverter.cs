using System.Globalization;

namespace ConvertersMauiApp.Converters
{
    class BoolToColorConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null
                || value is not bool)
                return Binding.DoNothing;

            bool isChecked = (bool)value;
            if (isChecked)
                return new Color(0, 255, 0);
            else
                return Colors.Red;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
