using CountryComboBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

public class CountryComboBoxUC
{
	public static CountryDropdown cd = null;
	public static Label lblLang = null;

	public static void SetToRowWitlLabel(ref bool loaded, Label lblLang, int row, string ThisAppL, IResourceHelper embeddedResourcesH, Grid grid, Action<string> Cd_SelectionChanged)
    {
		#region lblLang
		
		lblLang.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
		Grid.SetRow(lblLang, row);


		grid.Children.Add(lblLang);
		#endregion

		#region lang
		cd = new CountryDropdown();
		var sc = LocaleHelper.GetCountryForLang2(ThisAppL);
		cd.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;

		cd.SelectedCountry = sc;
		cd.SelectionChanged += Cd_SelectionChanged;

		Grid.SetRow(cd, row);
		Grid.SetColumn(cd, 1);

		cd.Init(embeddedResourcesH.GetStream("XML/countries.xml"));

		grid.Children.Add(cd);
		#endregion
	}
}