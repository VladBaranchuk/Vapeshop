using System;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Veipshop.Service
{
    public class ImagePathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return new BitmapImage(new Uri(Environment.CurrentDirectory + "/Images/Products/" + value.ToString() + ".png"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
