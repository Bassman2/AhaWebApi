using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;

namespace AVMHomeAutomationDemo.Converter
{
    [ValueConversion(typeof(List<Enum>), typeof(string))]
    public class EnumListToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            IEnumerable enumerable = (IEnumerable)value;
            return enumerable.Cast<Enum>().Select((i) => i.ToString()).Aggregate(string.Empty, (a, b) => $"{a},{b}").TrimStart(',');
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
