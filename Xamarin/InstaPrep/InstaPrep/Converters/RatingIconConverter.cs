using System;
using System.Globalization;
using FFImageLoading.Svg.Forms;
using Xamarin.Forms;

namespace InstaPrep.Converters
{
    public class RatingIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int)
            {
                switch (value)
                {
                    case 1:
                        return SvgImageSource.FromResource("InstaPrep.SVG.star_1.svg");
                    case 2:
                        return SvgImageSource.FromResource("InstaPrep.SVG.star_2.svg");
                    case 3:
                        return SvgImageSource.FromResource("InstaPrep.SVG.star_3.svg");
                    default:
                        throw new Exception($"RatingIconConverter: Rating out of range");
                }
            }
            else
                throw new Exception($"RatingIconConverter: Exspecting 'Int'");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

