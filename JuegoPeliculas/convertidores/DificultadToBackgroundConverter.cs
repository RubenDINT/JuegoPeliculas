using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace JuegoPeliculas.convertidores
{
    class DificultadToBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case "Fácil":
                    return Brushes.LightGreen;
                case "Media":
                    return Brushes.Khaki;
                case "Difícil":
                    return Brushes.Tomato;
                default:
                    return Brushes.White;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
