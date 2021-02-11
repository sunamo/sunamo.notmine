using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using SunamoExceptions;

namespace PathEditor.Views.Support
{
    public class PathExistenceToBrushConverter : IValueConverter
    {
        static Type type = typeof(PathExistenceToBrushConverter);
        private static readonly SolidColorBrush NotExistsBrush = new SolidColorBrush(Colors.Yellow);
        private static readonly SolidColorBrush ExistsBrush = new SolidColorBrush(Colors.Transparent);

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool))
                return ExistsBrush;

            var exists = (bool) value;
            return exists ? ExistsBrush : NotExistsBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ThrowExceptions.NotImplementedMethod(Exc.GetStackTrace(), type, Exc.CallingMethod());
            return null;
        }
    }
}