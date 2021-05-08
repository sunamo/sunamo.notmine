using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.IO;

namespace CountryComboBox
{
    /// <summary>
    /// Original from https://www.codeproject.com/Articles/182759/WPF-Country-Combobox
    /// </summary>
    public partial class CountryDropdown : UserControl
    {
        /// <summary>
        /// Then you have to manually call init
        /// </summary>
        public CountryDropdown()
        {
            InitializeComponent();

            CountryrCombo.SelectionChanged += CountryrCombo_SelectionChanged;
        }

        public event Action<string> SelectionChanged;

        private void CountryrCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var d = e.AddedItems[0];
            var drv = (DataRowView)d;
            var shortcutCountry = drv.Row[0];

            if (SelectionChanged != null)
            {
                SelectionChanged(shortcutCountry.ToString());
            }

            int s = 0;
        }

        /// <summary>
        /// Create EmbeddedResourcesH 
        /// Insert stream from XML\countries.xml
        /// </summary>
        /// <param name="streamCountriesXml"></param>

        public void Init(Stream streamCountriesXml)
        {
            Countries = GetData(streamCountriesXml);
        }

        public DataTable Countries
        {
            get { return (DataTable)GetValue(CountriesProperty); }
            set { SetValue(CountriesProperty, value); }
        }

        
        public static readonly DependencyProperty CountriesProperty =
            DependencyProperty.Register("Countries", typeof(DataTable), typeof(CountryDropdown), new UIPropertyMetadata(null));

        public String SelectedCountry
        {
            get { return (String)GetValue(SelectedCountryProperty); }
            set { SetValue(SelectedCountryProperty, value); }
        }

       
        public static readonly DependencyProperty SelectedCountryProperty =
            DependencyProperty.Register("SelectedCountry", typeof(String), typeof(CountryDropdown), new UIPropertyMetadata(null));

        public DataTable GetData(Stream streamCountriesXml)
        {
            DataTable dt = new DataTable();

            DataSet ds = new DataSet();

            // streamCountriesXml = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "XML\\countries.xml", FileMode.OpenOrCreate);

            ds.ReadXml(streamCountriesXml);
            return ds.Tables[0];
        }

    }
}