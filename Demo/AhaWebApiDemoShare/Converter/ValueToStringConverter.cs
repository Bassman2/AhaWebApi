using System.Diagnostics;
using System.Windows.Data;

namespace AVMHomeAutomationDemo.Converter
{
    //[ValueConversion(typeof(IXmlNullable), typeof(string))]
    public class ValueToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string res = "---";

            string name = value?.GetType().Name ?? "Null";
            switch(name)
            {
            case nameof(Boolean):
                //res = (bool)value ? "On" : "Off"; 
                break;
            case nameof(Int32):
                //res = ((int)value).ToString();
                break;
            case nameof(Double):
                double val = (double)value!;
                switch ((Unit)parameter)
                {
                case Unit.Temperature:
                    if (val == double.MinValue)
                    {
                        res = "Off";
                    }
                    else if (val == double.MaxValue)
                    {
                        res = "On";
                    }
                    else
                    {
                        res = $"{val:N1} °C";
                    }
                    break;
                case Unit.Power:
                    res = $"{val:N3} W";
                    break;
                case Unit.Energy:
                    res = $"{val:N3} kWh";
                    break;
                case Unit.Voltage:
                    res = $"{val:N3} V";
                    break;
                default:
                    Debugger.Break();
                    break;
                }
                break;
            case nameof(DateTime):
                //res = ((DateTime)value).ToString();
                break;
            case "Null":
                res = "---";
                break;
            default:
                Debugger.Break();
                break;
            }

            //IXmlNullable xmlNullable = (IXmlNullable)value;
            //if (xmlNullable.HasValue)
            //{
            //    switch (value.GetType().Name)
            //    {
            //    case nameof(XmlNullableBool):
            //        res = ((XmlNullableBool)value).Value ? "On" : "Off";
            //        break;
            //    case nameof(XmlNullableInt):
            //        res = ((XmlNullableInt)value).Value.ToString();
            //        break;
            //    case nameof(XmlNullableDateTime):
            //        res = ((XmlNullableDateTime)value).Value.ToString();
            //        break;
            //    case nameof(XmlNullableKilo):
            //        double val = ((XmlNullableKilo)value).Value;
            //        switch ((Unit)parameter)
            //        {
            //        case Unit.Power:
            //            res = $"{val:N3} W";
            //            break;
            //        case Unit.Energy:
            //            res = $"{val:N3} kWh";
            //            break;
            //        case Unit.Voltage:
            //            res = $"{val:N3} V";
            //            break;
            //        default:
            //            Debugger.Break();
            //            break;
            //        }
            //        break;
            //    case nameof(XmlNullableTemperature):
            //        val = ((XmlNullableTemperature)value).Value;
            //        res = $"{val:N1} °C";
            //        break;
            //    case nameof(XmlNullableHkrTemperature):
            //        val = ((XmlNullableHkrTemperature)value).Value;
            //        if (val == double.MaxValue)
            //        {
            //            res = "On";
            //        }
            //        else if (val == double.MinValue)
            //        {
            //            res = "Off";
            //        }
            //        else
            //        {
            //            res = $"{val:N1} °C";
            //        }
            //        break;
            //    default:
            //        Debugger.Break();
            //        break;
            //    }
            //}
            return res;            
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
