using System;
using System.Globalization;
using System.Windows.Data;
using SunamoExceptions;

namespace PathEditor.Views.Support
{
    public class PathSelectionToEnabledConverter : IValueConverter
    {
        static Type type = typeof(PathSelectionToEnabledConverter);

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ThrowExceptions.NotImplementedMethod(Exc.GetStackTrace(), type, Exc.CallingMethod());
            return null;
        }
    }
}