using CommunityToolkit.Maui.Converters;
using System.Globalization;

namespace App.Converters
{
    internal class Base64ToImageSourceConverter : ByteArrayToImageSourceConverter, IValueConverter
    {

        // =============================================== //
        //          Methods
        // =============================================== //

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var base64 = value as string;
                byte[] bytes = System.Convert.FromBase64String(base64);
                return ConvertFrom(bytes);
            }
            catch { return null; }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var source = value as ImageSource;
                var bytes = ConvertBackTo(source);
                return System.Convert.ToBase64String(bytes);
            }
            catch
            {
                return null;
            }
        }
    }
}
