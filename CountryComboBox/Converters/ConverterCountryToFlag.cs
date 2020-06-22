using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Globalization;
using CountryComboBox;
using SunamoExceptions;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace CountryComboBox
{
    public class ConverterCountryToFlag : IValueConverter
    {
        static Type type = typeof(ConverterCountryToFlag);

        public object Convert(object value, Type targetType,
        object parameter, CultureInfo culture)
        {
            var v = value.ToString();
            var l = LocaleHelper.GetLangForCountry2(v);

            //Langs l = (Langs)Enum.Parse(typeof(Langs), lang);

            if (l.HasValue)
            {
                Bitmap bmp = null;

                switch (l.Value)
                {
                    case Langs.cs:
                        bmp = Resources.cz;
                        break;
                    case Langs.en:
                        bmp = Resources.gb;
                        break;
                    default:
                        break;
                }

                if (bmp != null)
                {
                    return ImageSourceHelper.ImageSourceFromBitmap2(bmp);
                }
            }

            ThrowExceptions.NotImplementedCase(Exc.GetStackTrace(), type, Exc.CallingMethod(), SH.NullToStringOrDefault(l));
            return null;

            //string urImage = AppDomain.CurrentDomain.BaseDirectory + "Images\\Countries\\"+ value.ToString() + ".png";
            //return urImage;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            return null;
        }

    }
}
