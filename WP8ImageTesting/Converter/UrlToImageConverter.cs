using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WP8ImageTesting.Converter
{
    public class UrlToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string ImageUrl = value as string;
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.CreateOptions = BitmapCreateOptions.None;
            bitmapImage.UriSource = new Uri(ImageUrl, UriKind.RelativeOrAbsolute);
            return bitmapImage;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
