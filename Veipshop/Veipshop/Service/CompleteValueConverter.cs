using System;
using System.Windows.Data;

namespace Veipshop.Service
{
    class CompleteValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string val = value as string;

            if(val == "true")
            {
                return "Статус заказа: готов";
            }
            else if (val == "false")
            {
                return "Статус заказа: подготавливается";
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}

