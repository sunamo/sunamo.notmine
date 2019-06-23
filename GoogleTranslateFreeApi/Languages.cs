using System.Runtime.Serialization;

namespace GoogleTranslateFreeApi
{
	/// <summary>
	/// Represents language
	/// </summary>
	public partial class Language
	{
		/// <summary>
		/// Auto Detection Language
		/// </summary>
		[DataMember]
		public static Language Auto { get; public set; }

		/// <summary>
		/// Afrikaans Language
		/// </summary>
		[DataMember]
		[Language("af")]
		public static Language Afrikaans { get; public set; }

		/// <summary>
		/// Albanian Language
		/// </summary>
		[DataMember]
		[Language("sq")]
		public static Language Albanian { get; public set; }

		/// <summary>
		/// Amharic Language
		/// </summary>
		[DataMember]
		[Language("am")]
		public static Language Amharic { get; public set; }

		/// <summary>
		/// Arabic Language
		/// </summary>
		[DataMember]
		[Language("ar")]
		public static Language Arabic { get; public set; }

		/// <summary>
		/// Armenian Language
		/// </summary>
		[DataMember]
		[Language("hy")]
		public static Language Armenian { get; public set; }

		/// <summary>
		/// Azerbaijani Language
		/// </summary>
		[DataMember]
		[Language("az")]
		public static Language Azerbaijani { get; public set; }

		/// <summary>
		/// Basque Language
		/// </summary>
		[DataMember]
		[Language("eu")]
		public static Language Basque { get; public set; }

		/// <summary>
		/// Belarusian Language
		/// </summary>
		[DataMember]
		[Language("be")]
		public static Language Belarusian { get; public set; }

		/// <summary>
		/// Bengali Language
		/// </summary>
		[DataMember]
		[Language("bn")]
		public static Language Bengali { get; public set; }

		/// <summary>
		/// Bosnian Language
		/// </summary>
		[DataMember]
		[Language("bs")]
		public static Language Bosnian { get; public set; }

		/// <summary>
		/// Bulgarian Language
		/// </summary>
		[DataMember]
		[Language("bg")]
		public static Language Bulgarian { get; public set; }

		/// <summary>
		/// Catalan Language
		/// </summary>
		[DataMember]
		[Language("ca")]
		public static Language Catalan { get; public set; }

		/// <summary>
		/// Cebuano Language
		/// </summary>
		[DataMember]
		[Language("ceb")]
		public static Language Cebuano { get; public set; }

		/// <summary>
		/// Chichewa Language
		/// </summary>
		[DataMember]
		[Language("ny")]
		public static Language Chichewa { get; public set; }

		/// <summary>
		/// Chinese Simplified Language
		/// </summary>
		[DataMember]
		[Language("zh-cn", "Chinese Simplified")]
		public static Language ChineseSimplified { get; public set; }

		/// <summary>
		/// Chinese Traditional Language
		/// </summary>
		[DataMember]
		[Language("zh-tw", "Chinese Traditional")]
		public static Language ChineseTraditional { get; public set; }

		/// <summary>
		/// Corsican Language
		/// </summary>
		[DataMember]
		[Language("co")]
		public static Language Corsican { get; public set; }

		/// <summary>
		/// Croatian Language
		/// </summary>
		[DataMember]
		[Language("hr")]
		public static Language Croatian { get; public set; }

		/// <summary>
		/// Czech Language
		/// </summary>
		[DataMember]
		[Language("cs")]
		public static Language Czech { get; public set; }

		/// <summary>
		/// Danish Language
		/// </summary>
		[DataMember]
		[Language("da")]
		public static Language Danish { get; public set; }

		/// <summary>
		/// Dutch Language
		/// </summary>
		[DataMember]
		[Language("nl")]
		public static Language Dutch { get; public set; }

		/// <summary>
		/// English Language
		/// </summary>
		[DataMember]
		[Language("en")]
		public static Language English { get; public set; }

		/// <summary>
		/// Esperanto Language
		/// </summary>
		[DataMember]
		[Language("eo")]
		public static Language Esperanto { get; public set; }

		/// <summary>
		/// Estonian Language
		/// </summary>
		[DataMember]
		[Language("et")]
		public static Language Estonian { get; public set; }

		/// <summary>
		/// Filipino Language
		/// </summary>
		[DataMember]
		[Language("tl")]
		public static Language Filipino { get; public set; }

		/// <summary>
		/// Finnish Language
		/// </summary>
		[DataMember]
		[Language("fi")]
		public static Language Finnish { get; public set; }

		/// <summary>
		/// French Language
		/// </summary>
		[DataMember]
		[Language("fr")]
		public static Language French { get; public set; }

		/// <summary>
		/// Frisian Language
		/// </summary>
		[DataMember]
		[Language("fy")]
		public static Language Frisian { get; public set; }

		/// <summary>
		/// Galician Language
		/// </summary>
		[DataMember]
		[Language("gl")]
		public static Language Galician { get; public set; }

		/// <summary>
		/// Georgian Language
		/// </summary>
		[DataMember]
		[Language("ka")]
		public static Language Georgian { get; public set; }

		/// <summary>
		/// German Language
		/// </summary>
		[DataMember]
		[Language("de")]
		public static Language German { get; public set; }

		/// <summary>
		/// Greek Language
		/// </summary>
		[DataMember]
		[Language("el")]
		public static Language Greek { get; public set; }

		/// <summary>
		/// Gujarati Language
		/// </summary>
		[DataMember]
		[Language("gu")]
		public static Language Gujarati { get; public set; }

		/// <summary>
		/// Haitian Creole Language
		/// </summary>
		[DataMember]
		[Language("ht", "Haitian Creole")]
		public static Language HaitianCreole { get; public set; }

		/// <summary>
		/// Hausa Language
		/// </summary>
		[DataMember]
		[Language("ha")]
		public static Language Hausa { get; public set; }

		/// <summary>
		/// Hawaiian Language
		/// </summary>
		[DataMember]
		[Language("haw")]
		public static Language Hawaiian { get; public set; }

		/// <summary>
		/// Hebrew Language
		/// </summary>
		[DataMember]
		[Language("iw")]
		public static Language Hebrew { get; public set; }

		/// <summary>
		/// Hindi Language
		/// </summary>
		[DataMember]
		[Language("hi")]
		public static Language Hindi { get; public set; }

		/// <summary>
		/// Hmong Language
		/// </summary>
		[DataMember]
		[Language("hmn")]
		public static Language Hmong { get; public set; }

		/// <summary>
		/// Hungarian Language
		/// </summary>
		[DataMember]
		[Language("hu")]
		public static Language Hungarian { get; public set; }

		/// <summary>
		/// Icelandic Language
		/// </summary>
		[DataMember]
		[Language("is")]
		public static Language Icelandic { get; public set; }

		/// <summary>
		/// Igbo Language
		/// </summary>
		[DataMember]
		[Language("ig")]
		public static Language Igbo { get; public set; }

		/// <summary>
		/// Indonesian Language
		/// </summary>
		[DataMember]
		[Language("id")]
		public static Language Indonesian { get; public set; }

		/// <summary>
		/// Irish Language
		/// </summary>
		[DataMember]
		[Language("ga")]
		public static Language Irish { get; public set; }

		/// <summary>
		/// Italian Language
		/// </summary>
		[DataMember]
		[Language("it")]
		public static Language Italian { get; public set; }

		/// <summary>
		/// Japanese Language
		/// </summary>
		[DataMember]
		[Language("ja")]
		public static Language Japanese { get; public set; }

		/// <summary>
		/// Javanese Language
		/// </summary>
		[DataMember]
		[Language("jw")]
		public static Language Javanese { get; public set; }

		/// <summary>
		/// Kannada Language
		/// </summary>
		[DataMember]
		[Language("kn")]
		public static Language Kannada { get; public set; }

		/// <summary>
		/// Kazakh Language
		/// </summary>
		[DataMember]
		[Language("kk")]
		public static Language Kazakh { get; public set; }

		/// <summary>
		/// Khmer Language
		/// </summary>
		[DataMember]
		[Language("km")]
		public static Language Khmer { get; public set; }

		/// <summary>
		/// Korean Language
		/// </summary>
		[DataMember]
		[Language("ko")]
		public static Language Korean { get; public set; }

		/// <summary>
		/// Kurdish (Kurmanji) Language
		/// </summary>
		[DataMember]
		[Language("ku", "Kurdish Kurmanji")]
		public static Language KurdishKurmanji { get; public set; }

		/// <summary>
		/// Kyrgyz Language
		/// </summary>
		[DataMember]
		[Language("ky")]
		public static Language Kyrgyz { get; public set; }

		/// <summary>
		/// Lao Language
		/// </summary>
		[DataMember]
		[Language("lo")]
		public static Language Lao { get; public set; }

		/// <summary>
		/// Latin Language
		/// </summary>
		[DataMember]
		[Language("la")]
		public static Language Latin { get; public set; }

		/// <summary>
		/// Latvian Language
		/// </summary>
		[DataMember]
		[Language("lv")]
		public static Language Latvian { get; public set; }

		/// <summary>
		/// Lithuanian Language
		/// </summary>
		[DataMember]
		[Language("lt")]
		public static Language Lithuanian { get; public set; }

		/// <summary>
		/// Luxembourgish Language
		/// </summary>
		[DataMember]
		[Language("lb")]
		public static Language Luxembourgish { get; public set; }

		/// <summary>
		/// Macedonian Language
		/// </summary>
		[DataMember]
		[Language("mk")]
		public static Language Macedonian { get; public set; }

		/// <summary>
		/// Malagasy Language
		/// </summary>
		[DataMember]
		[Language("mg")]
		public static Language Malagasy { get; public set; }

		/// <summary>
		/// Malay Language
		/// </summary>
		[DataMember]
		[Language("ms")]
		public static Language Malay { get; public set; }

		/// <summary>
		/// Malayalam Language
		/// </summary>
		[DataMember]
		[Language("ml")]
		public static Language Malayalam { get; public set; }

		/// <summary>
		/// Maltese Language
		/// </summary>
		[DataMember]
		[Language("mt")]
		public static Language Maltese { get; public set; }

		/// <summary>
		/// Maori Language
		/// </summary>
		[DataMember]
		[Language("mi")]
		public static Language Maori { get; public set; }

		/// <summary>
		/// Marathi Language
		/// </summary>
		[DataMember]
		[Language("mr")]
		public static Language Marathi { get; public set; }

		/// <summary>
		/// Mongolian Language
		/// </summary>
		[DataMember]
		[Language("mn")]
		public static Language Mongolian { get; public set; }

		/// <summary>
		/// Myanmar (Burmese) Language
		/// </summary>
		[DataMember]
		[Language("my", "Myanmar Burmese")]
		public static Language MyanmarBurmese { get; public set; }

		/// <summary>
		/// Nepali Language
		/// </summary>
		[DataMember]
		[Language("ne")]
		public static Language Nepali { get; public set; }

		/// <summary>
		/// Norwegian Language
		/// </summary>
		[DataMember]
		[Language("no")]
		public static Language Norwegian { get; public set; }

		/// <summary>
		/// Pashto Language
		/// </summary>
		[DataMember]
		[Language("ps")]
		public static Language Pashto { get; public set; }

		/// <summary>
		/// Persian Language
		/// </summary>
		[DataMember]
		[Language("fa")]
		public static Language Persian { get; public set; }

		/// <summary>
		/// Polish Language
		/// </summary>
		[DataMember]
		[Language("pl")]
		public static Language Polish { get; public set; }

		/// <summary>
		/// Portuguese Language
		/// </summary>
		[DataMember]
		[Language("pt")]
		public static Language Portuguese { get; public set; }

		/// <summary>
		/// Punjabi Language
		/// </summary>
		[DataMember]
		[Language("ma")]
		public static Language Punjabi { get; public set; }

		/// <summary>
		/// Romanian Language
		/// </summary>
		[DataMember]
		[Language("ro")]
		public static Language Romanian { get; public set; }

		/// <summary>
		/// Russian Language
		/// </summary>
		[DataMember]
		[Language("ru")]
		public static Language Russian { get; public set; }

		/// <summary>
		/// Samoan Language
		/// </summary>
		[DataMember]
		[Language("sm")]
		public static Language Samoan { get; public set; }

		/// <summary>
		/// Scots Gaelic Language
		/// </summary>
		[DataMember]
		[Language("gd")]
		public static Language ScotsGaelic { get; public set; }

		/// <summary>
		/// Serbian Language
		/// </summary>
		[DataMember]
		[Language("sr")]
		public static Language Serbian { get; public set; }

		/// <summary>
		/// Sesotho Language
		/// </summary>
		[DataMember]
		[Language("st")]
		public static Language Sesotho { get; public set; }

		/// <summary>
		/// Shona Language
		/// </summary>
		[DataMember]
		[Language("sn")]
		public static Language Shona { get; public set; }

		/// <summary>
		/// Sindhi Language
		/// </summary>
		[DataMember]
		[Language("sd")]
		public static Language Sindhi { get; public set; }

		/// <summary>
		/// Sinhala Language
		/// </summary>
		[DataMember]
		[Language("si")]
		public static Language Sinhala { get; public set; }

		/// <summary>
		/// Slovak Language
		/// </summary>
		[DataMember]
		[Language("sk")]
		public static Language Slovak { get; public set; }

		/// <summary>
		/// Slovenian Language
		/// </summary>
		[DataMember]
		[Language("sl")]
		public static Language Slovenian { get; public set; }

		/// <summary>
		/// Somali Language
		/// </summary>
		[DataMember]
		[Language("so")]
		public static Language Somali { get; public set; }

		/// <summary>
		/// Spanish Language
		/// </summary>
		[DataMember]
		[Language("es")]
		public static Language Spanish { get; public set; }

		/// <summary>
		/// Sundanese Language
		/// </summary>
		[DataMember]
		[Language("su")]
		public static Language Sundanese { get; public set; }

		/// <summary>
		/// Swahili Language
		/// </summary>
		[DataMember]
		[Language("sw")]
		public static Language Swahili { get; public set; }

		/// <summary>
		/// Swedish Language
		/// </summary>
		[DataMember]
		[Language("sv")]
		public static Language Swedish { get; public set; }

		/// <summary>
		/// Tajik Language
		/// </summary>
		[DataMember]
		[Language("tg")]
		public static Language Tajik { get; public set; }

		/// <summary>
		/// Tamil Language
		/// </summary>
		[DataMember]
		[Language("ta")]
		public static Language Tamil { get; public set; }

		/// <summary>
		/// Telugu Language
		/// </summary>
		[DataMember]
		[Language("te")]
		public static Language Telugu { get; public set; }

		/// <summary>
		/// Thai Language
		/// </summary>
		[DataMember]
		[Language("th")]
		public static Language Thai { get; public set; }

		/// <summary>
		/// Turkish Language
		/// </summary>
		[DataMember]
		[Language("tr")]
		public static Language Turkish { get; public set; }

		/// <summary>
		/// Ukrainian Language
		/// </summary>
		[DataMember]
		[Language("uk")]
		public static Language Ukrainian { get; public set; }

		/// <summary>
		/// Urdu Language
		/// </summary>
		[DataMember]
		[Language("ur")]
		public static Language Urdu { get; public set; }

		/// <summary>
		/// Uzbek Language
		/// </summary>
		[DataMember]
		[Language("uz")]
		public static Language Uzbek { get; public set; }

		/// <summary>
		/// Vietnamese Language
		/// </summary>
		[DataMember]
		[Language("vi")]
		public static Language Vietnamese { get; public set; }

		/// <summary>
		/// Welsh Language
		/// </summary>
		[DataMember]
		[Language("cy")]
		public static Language Welsh { get; public set; }

		/// <summary>
		/// Xhosa Language
		/// </summary>
		[DataMember]
		[Language("xh")]
		public static Language Xhosa { get; public set; }

		/// <summary>
		/// Yiddish Language
		/// </summary>
		[DataMember]
		[Language("yi")]
		public static Language Yiddish { get; public set; }

		/// <summary>
		/// Yoruba Language
		/// </summary>
		[DataMember]
		[Language("yo")]
		public static Language Yoruba { get; public set; }

		/// <summary>
		/// Zulu Language
		/// </summary>
		[DataMember]
		[Language("zu")]
		public static Language Zulu { get; public set; }


	}
}