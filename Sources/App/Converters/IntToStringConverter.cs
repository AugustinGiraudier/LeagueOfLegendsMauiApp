using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Converters
{
    class IntToStringConverter : IValueConverter
    {

        // =============================================== //
        //          Methods
        // =============================================== //

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = (int)value;
            return val.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var str = (string)value;
                return int.Parse(str);
            }
            catch {
                return 0;
            }
        }
    }
}
