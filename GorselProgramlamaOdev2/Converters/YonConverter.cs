using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorselProgramlamaOdev2.Converters 
{
    public class YonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value.ToString() == "caret-down")
            {
                return Color.FromRgba(255, 0, 0, 255);
            }
            else if (value != null && value.ToString() == "minus")
            {
                return Color.FromRgba(247, 202, 24, 255);
            }

            return Color.FromRgba(0, 128, 0, 255);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
