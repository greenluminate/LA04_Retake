using SuperheroManager.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace SuperheroManager.Helpers
{
    public partial class EnumToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((SideEnum)value==SideEnum.good)
            {
                return Brushes.LightGreen;
            }
            else if ((SideEnum)value == SideEnum.evil)
            {
                return Brushes.LightPink;
            }
            else
            {
                return Brushes.LightYellow;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
