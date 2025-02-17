using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AVMHomeAutomationDemo.Converter
{
    [ValueConversion(typeof(bool), typeof(ImageSource))]
    public class BoolToBallImageConverter : IValueConverter
    {
        private static readonly ImageSource greenBall;
        private static readonly ImageSource grayBall;

        static BoolToBallImageConverter()
        {
            greenBall = new BitmapImage(new Uri("pack://application:,,,/Images/GreenBall.png"));
            grayBall = new BitmapImage(new Uri("pack://application:,,,/Images/GrayBall.png"));
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool val = (bool)value;
            return val ? greenBall : grayBall;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
