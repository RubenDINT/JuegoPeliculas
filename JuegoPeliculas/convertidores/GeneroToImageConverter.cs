using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace JuegoPeliculas.convertidores
{
    class GeneroToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case "Drama":
                    return "assets/drama.png";
                case "Comedia":
                    return "assets/comedy.png";
                case "Acción":
                    return "assets/action.png";
                case "Ciencia-Ficción":
                    return "assets/science.png";
                case "Terror":
                    return "assets/terror.png";
                default:
                    return "assets/default.png";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
