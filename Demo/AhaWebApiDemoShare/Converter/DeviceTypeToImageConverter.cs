using AVMHomeAutomation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AVMHomeAutomationDemo.Converter
{
    [ValueConversion(typeof(DeviceType), typeof(ImageSource))]
    public class DeviceTypeToImageConverter : IValueConverter
    {
        private static readonly ImageSource imgButton;
        private static readonly ImageSource imgControl;
        private static readonly ImageSource imgDoorContact;
        private static readonly ImageSource imgHeater;
        private static readonly ImageSource imgLight;
        private static readonly ImageSource imgMotionDetector;
        private static readonly ImageSource imgRepeater;
        private static readonly ImageSource imgRollotron;
        private static readonly ImageSource imgSocket;
        private static readonly ImageSource imgWallbutton;
        
        static DeviceTypeToImageConverter()
        {
            imgButton = new BitmapImage(new Uri("pack://application:,,,/Images/Button.png"));
            imgControl = new BitmapImage(new Uri("pack://application:,,,/Images/Control.png"));
            imgDoorContact = new BitmapImage(new Uri("pack://application:,,,/Images/DoorContact.png"));
            imgHeater = new BitmapImage(new Uri("pack://application:,,,/Images/Heater.png"));
            imgLight = new BitmapImage(new Uri("pack://application:,,,/Images/Light.png"));
            imgMotionDetector = new BitmapImage(new Uri("pack://application:,,,/Images/MotionDetector.png"));
            imgRepeater = new BitmapImage(new Uri("pack://application:,,,/Images/Repeater.png"));
            imgRollotron = new BitmapImage(new Uri("pack://application:,,,/Images/Rollotron.png"));
            imgSocket = new BitmapImage(new Uri("pack://application:,,,/Images/Socket.png"));
            imgWallbutton = new BitmapImage(new Uri("pack://application:,,,/Images/Wallbutton.png"));
        }

        public object? Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DeviceType deviceType = (DeviceType)value;
            ImageSource? img = null;
            switch (deviceType)
            {
            case DeviceType.Button: img = imgButton; break;
            case DeviceType.Control: img = imgControl; break;
            case DeviceType.DoorContact: img = imgDoorContact; break;
            case DeviceType.Heater: img = imgHeater; break;
            case DeviceType.Light: img = imgLight; break;
            case DeviceType.MotionDetector: img = imgMotionDetector; break;
            case DeviceType.Repeater: img = imgRepeater; break;
            case DeviceType.Rollotron: img = imgRollotron; break;
            case DeviceType.Socket: img = imgSocket; break;
            case DeviceType.Wallbutton: img = imgWallbutton; break;
            }
            return img;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
