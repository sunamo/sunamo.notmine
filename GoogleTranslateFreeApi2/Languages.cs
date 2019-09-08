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
		public static Language Auto { get; set; }

		/// <summary>
		/// Afrikaans Language
		/// </summary>
		[DataMember]
		[Language("af")]
		public static Language Afrikaans { get; set; }

		/// <summary>
		/// Albanian Language
		/// </summary>
		[DataMember]
		[Language("sq")]
		public static Language Albanian { get; set; }

		/// <summary>
		/// Amharic Language
		/// </summary>
		[DataMember]
		[Language("am")]
		public static Language Amharic { get; set; }

		/// <summary>
		/// Arabic Language
		/// </summary>
		[DataMember]
		[Language("ar")]
		public static Language Arabic { get; set; }

		/// <summary>
		/// Armenian Language
		/// </summary>
		[DataMember]
		[Language("hy")]
		public static Language Armenian { get; set; }

		/// <summary>
		/// Azerbaijani Language
		/// </summary>
		[DataMember]
		[Language("az")]
		public static Language Azerbaijani { get; set; }

		/// <summary>
		/// Basque Language
		/// </summary>
		[DataMember]
		[Language("eu")]
		public static Language Basque { get; set; }

		/// <summary>
		/// Belarusian Language
		/// </summary>
		[DataMember]
		[Language("be")]
		public static Language Belarusian { get; set; }

		/// <summary>
		/// Bengali Language
		/// </summary>
		[DataMember]
		[Language("bn")]
		public static Language Bengali { get; set; }

		/// <summary>
		/// Bosnian Language
		/// </summary>
		[DataMember]
		[Language("bs")]
		public static Language Bosnian { get; set; }

		/// <summary>
		/// Bulgarian Language
		/// </summary>
		[DataMember]
		[Language("bg")]
		public static Language Bulgarian { get; set; }

		/// <summary>
		/// Catalan Language
		/// </summary>
		[DataMember]
		[Language("ca")]
		public static Language Catalan { get; set; }

		/// <summary>
		/// Cebuano Language
		/// </summary>
		[DataMember]
		[Language("ceb")]
		public static Language Cebuano { get; set; }

		/// <summary>
		/// Chichewa Language
		/// </summary>
		[DataMember]
		[Language("ny")]
		public static Language Chichewa { get; set; }

		/// <summary>
		/// Chinese Simplified Language
		/// </summary>
		[DataMember]
		[Language("zh-cn", "Chinese Simplified")]
		public static Language ChineseSimplified { get; set; }

		/// <summary>
		/// Chinese Traditional Language
		/// </summary>
		[DataMember]
		[Language("zh-tw", "Chinese Traditional")]
		public static Language ChineseTraditional { get; set; }

		/// <summary>
		/// Corsican Language
		/// </summary>
		[DataMember]
		[Language("co")]
		public static Language Corsican { get; set; }

		/// <summary>
		/// Croatian Language
		/// </summary>
		[DataMember]
		[Language("hr")]
		public static Language Croatian { get; set; }

		/// <summary>
		/// Czech Language
		/// </summary>
		[DataMember]
		[Language("cs")]
		public static Language Czech { get; set; }

		/// <summary>
		/// Danish Language
		/// </summary>
		[DataMember]
		[Language("da")]
		public static Language Danish { get; set; }

		/// <summary>
		/// Dutch Language
		/// </summary>
		[DataMember]
		[Language("nl")]
		public static Language Dutch { get; set; }

		/// <summary>
		/// English Language
		/// </summary>
		[DataMember]
		[Language("en")]
		public static Language English { get; set; }

		/// <summary>
		/// Esperanto Language
		/// </summary>
		[DataMember]
		[Language("eo")]
		public static Language Esperanto { get; set; }

		/// <summary>
		/// Estonian Language
		/// </summary>
		[DataMember]
		[Language("et")]
		public static Language Estonian { get; set; }

		/// <summary>
		/// Filipino Language
		/// </summary>
		[DataMember]
		[Language("tl")]
		public static Language Filipino { get; set; }

		/// <summary>
		/// Finnish Language
		/// </summary>
		[DataMember]
		[Language("fi")]
		public static Language Finnish { get; set; }

		/// <summary>
		/// French Language
		/// </summary>
		[DataMember]
		[Language("fr")]
		public static Language French { get; set; }

		/// <summary>
		/// Frisian Language
		/// </summary>
		[DataMember]
		[Language("fy")]
		public static Language Frisian { get; set; }

		/// <summary>
		/// Galician Language
		/// </summary>
		[DataMember]
		[Language("gl")]
		public static Language Galician { get; set; }

		/// <summary>
		/// Georgian Language
		/// </summary>
		[DataMember]
		[Language("ka")]
		public static Language Georgian { get; set; }

		/// <summary>
		/// German Language
		/// </summary>
		[DataMember]
		[Language("de")]
		public static Language German { get; set; }

		/// <summary>
		/// Greek Language
		/// </summary>
		[DataMember]
		[Language("el")]
		public static Language Greek { get; set; }

		/// <summary>
		/// Gujarati Language
		/// </summary>
		[DataMember]
		[Language("gu")]
		public static Language Gujarati { get; set; }

		/// <summary>
		/// Haitian Creole Language
		/// </summary>
		[DataMember]
		[Language("ht", "Haitian Creole")]
		public static Language HaitianCreole { get; set; }

		/// <summary>
		/// Hausa Language
		/// </summary>
		[DataMember]
		[Language("ha")]
		public static Language Hausa { get; set; }

		/// <summary>
		/// Hawaiian Language
		/// </summary>
		[DataMember]
		[Language("haw")]
		public static Language Hawaiian { get; set; }

		/// <summary>
		/// Hebrew Language
		/// </summary>
		[DataMember]
		[Language("iw")]
		public static Language Hebrew { get; set; }

		/// <summary>
		/// Hindi Language
		/// </summary>
		[DataMember]
		[Language("hi")]
		public static Language Hindi { get; set; }

		/// <summary>
		/// Hmong Language
		/// </summary>
		[DataMember]
		[Language("hmn")]
		public static Language Hmong { get; set; }

		/// <summary>
		/// Hungarian Language
		/// </summary>
		[DataMember]
		[Language("hu")]
		public static Language Hungarian { get; set; }

		/// <summary>
		/// Icelandic Language
		/// </summary>
		[DataMember]
		[Language("is")]
		public static Language Icelandic { get; set; }

		/// <summary>
		/// Igbo Language
		/// </summary>
		[DataMember]
		[Language("ig")]
		public static Language Igbo { get; set; }

		/// <summary>
		/// Indonesian Language
		/// </summary>
		[DataMember]
		[Language("id")]
		public static Language Indonesian { get; set; }

		/// <summary>
		/// Irish Language
		/// </summary>
		[DataMember]
		[Language("ga")]
		public static Language Irish { get; set; }

		/// <summary>
		/// Italian Language
		/// </summary>
		[DataMember]
		[Language("it")]
		public static Language Italian { get; set; }

		/// <summary>
		/// Japanese Language
		/// </summary>
		[DataMember]
		[Language("ja")]
		public static Language Japanese { get; set; }

		/// <summary>
		/// Javanese Language
		/// </summary>
		[DataMember]
		[Language("jw")]
		public static Language Javanese { get; set; }

		/// <summary>
		/// Kannada Language
		/// </summary>
		[DataMember]
		[Language("kn")]
		public static Language Kannada { get; set; }

		/// <summary>
		/// Kazakh Language
		/// </summary>
		[DataMember]
		[Language("kk")]
		public static Language Kazakh { get; set; }

		/// <summary>
		/// Khmer Language
		/// </summary>
		[DataMember]
		[Language("km")]
		public static Language Khmer { get; set; }

		/// <summary>
		/// Korean Language
		/// </summary>
		[DataMember]
		[Language("ko")]
		public static Language Korean { get; set; }

		/// <summary>
		/// Kurdish (Kurmanji) Language
		/// </summary>
		[DataMember]
		[Language("ku", "Kurdish Kurmanji")]
		public static Language KurdishKurmanji { get; set; }

		/// <summary>
		/// Kyrgyz Language
		/// </summary>
		[DataMember]
		[Language("ky")]
		public static Language Kyrgyz { get; set; }

		/// <summary>
		/// Lao Language
		/// </summary>
		[DataMember]
		[Language("lo")]
		public static Language Lao { get; set; }

		/// <summary>
		/// Latin Language
		/// </summary>
		[DataMember]
		[Language("la")]
		public static Language Latin { get; set; }

		/// <summary>
		/// Latvian Language
		/// </summary>
		[DataMember]
		[Language("lv")]
		public static Language Latvian { get; set; }

		/// <summary>
		/// Lithuanian Language
		/// </summary>
		[DataMember]
		[Language("lt")]
		public static Language Lithuanian { get; set; }

		/// <summary>
		/// Luxembourgish Language
		/// </summary>
		[DataMember]
		[Language("lb")]
		public static Language Luxembourgish { get; set; }

		/// <summary>
		/// Macedonian Language
		/// </summary>
		[DataMember]
		[Language("mk")]
		public static Language Macedonian { get; set; }

		/// <summary>
		/// Malagasy Language
		/// </summary>
		[DataMember]
		[Language("mg")]
		public static Language Malagasy { get; set; }

		/// <summary>
		/// Malay Language
		/// </summary>
		[DataMember]
		[Language("ms")]
		public static Language Malay { get; set; }

		/// <summary>
		/// Malayalam Language
		/// </summary>
		[DataMember]
		[Language("ml")]
		public static Language Malayalam { get; set; }

		/// <summary>
		/// Maltese Language
		/// </summary>
		[DataMember]
		[Language("mt")]
		public static Language Maltese { get; set; }

		/// <summary>
		/// Maori Language
		/// </summary>
		[DataMember]
		[Language("mi")]
		public static Language Maori { get; set; }

		/// <summary>
		/// Marathi Language
		/// </summary>
		[DataMember]
		[Language("mr")]
		public static Language Marathi { get; set; }

		/// <summary>
		/// Mongolian Language
		/// </summary>
		[DataMember]
		[Language("mn")]
		public static Language Mongolian { get; set; }

		/// <summary>
		/// Myanmar (Burmese) Language
		/// </summary>
		[DataMember]
		[Language("my", "Myanmar Burmese")]
		public static Language MyanmarBurmese { get; set; }

		/// <summary>
		/// Nepali Language
		/// </summary>
		[DataMember]
		[Language("ne")]
		public static Language Nepali { get; set; }

		/// <summary>
		/// Norwegian Language
		/// </summary>
		[DataMember]
		[Language("no")]
		public static Language Norwegian { get; set; }

		/// <summary>
		/// Pashto Language
		/// </summary>
		[DataMember]
		[Language("ps")]
		public static Language Pashto { get; set; }

		/// <summary>
		/// Persian Language
		/// </summary>
		[DataMember]
		[Language("fa")]
		public static Language Persian { get; set; }

		/// <summary>
		/// Polish Language
		/// </summary>
		[DataMember]
		[Language("pl")]
		public static Language Polish { get; set; }

		/// <summary>
		/// Portuguese Language
		/// </summary>
		[DataMember]
		[Language("pt")]
		public static Language Portuguese { get; set; }

		/// <summary>
		/// Punjabi Language
		/// </summary>
		[DataMember]
		[Language("ma")]
		public static Language Punjabi { get; set; }

		/// <summary>
		/// Romanian Language
		/// </summary>
		[DataMember]
		[Language("ro")]
		public static Language Romanian { get; set; }

		/// <summary>
		/// Russian Language
		/// </summary>
		[DataMember]
		[Language("ru")]
		public static Language Russian { get; set; }

		/// <summary>
		/// Samoan Language
		/// </summary>
		[DataMember]
		[Language("sm")]
		public static Language Samoan { get; set; }

		/// <summary>
		/// Scots Gaelic Language
		/// </summary>
		[DataMember]
		[Language("gd")]
		public static Language ScotsGaelic { get; set; }

		/// <summary>
		/// Serbian Language
		/// </summary>
		[DataMember]
		[Language("sr")]
		public static Language Serbian { get; set; }

		/// <summary>
		/// Sesotho Language
		/// </summary>
		[DataMember]
		[Language("st")]
		public static Language Sesotho { get; set; }

		/// <summary>
		/// Shona Language
		/// </summary>
		[DataMember]
		[Language("sn")]
		public static Language Shona { get; set; }

		/// <summary>
		/// Sindhi Language
		/// </summary>
		[DataMember]
		[Language("sd")]
		public static Language Sindhi { get; set; }

		/// <summary>
		/// Sinhala Language
		/// </summary>
		[DataMember]
		[Language("si")]
		public static Language Sinhala { get; set; }

		/// <summary>
		/// Slovak Language
		/// </summary>
		[DataMember]
		[Language("sk")]
		public static Language Slovak { get; set; }

		/// <summary>
		/// Slovenian Language
		/// </summary>
		[DataMember]
		[Language("sl")]
		public static Language Slovenian { get; set; }

		/// <summary>
		/// Somali Language
		/// </summary>
		[DataMember]
		[Language("so")]
		public static Language Somali { get; set; }

		/// <summary>
		/// Spanish Language
		/// </summary>
		[DataMember]
		[Language("es")]
		public static Language Spanish { get; set; }

		/// <summary>
		/// Sundanese Language
		/// </summary>
		[DataMember]
		[Language("su")]
		public static Language Sundanese { get; set; }

		/// <summary>
		/// Swahili Language
		/// </summary>
		[DataMember]
		[Language("sw")]
		public static Language Swahili { get; set; }

		/// <summary>
		/// Swedish Language
		/// </summary>
		[DataMember]
		[Language("sv")]
		public static Language Swedish { get; set; }

		/// <summary>
		/// Tajik Language
		/// </summary>
		[DataMember]
		[Language("tg")]
		public static Language Tajik { get; set; }

		/// <summary>
		/// Tamil Language
		/// </summary>
		[DataMember]
		[Language("ta")]
		public static Language Tamil { get; set; }

		/// <summary>
		/// Telugu Language
		/// </summary>
		[DataMember]
		[Language("te")]
		public static Language Telugu { get; set; }

		/// <summary>
		/// Thai Language
		/// </summary>
		[DataMember]
		[Language("th")]
		public static Language Thai { get; set; }

		/// <summary>
		/// Turkish Language
		/// </summary>
		[DataMember]
		[Language("tr")]
		public static Language Turkish { get; set; }

		/// <summary>
		/// Ukrainian Language
		/// </summary>
		[DataMember]
		[Language("uk")]
		public static Language Ukrainian { get; set; }

		/// <summary>
		/// Urdu Language
		/// </summary>
		[DataMember]
		[Language("ur")]
		public static Language Urdu { get; set; }

		/// <summary>
		/// Uzbek Language
		/// </summary>
		[DataMember]
		[Language("uz")]
		public static Language Uzbek { get; set; }

		/// <summary>
		/// Vietnamese Language
		/// </summary>
		[DataMember]
		[Language("vi")]
		public static Language Vietnamese { get; set; }

		/// <summary>
		/// Welsh Language
		/// </summary>
		[DataMember]
		[Language("cy")]
		public static Language Welsh { get; set; }

		/// <summary>
		/// Xhosa Language
		/// </summary>
		[DataMember]
		[Language("xh")]
		public static Language Xhosa { get; set; }

		/// <summary>
		/// Yiddish Language
		/// </summary>
		[DataMember]
		[Language("yi")]
		public static Language Yiddish { get; set; }

		/// <summary>
		/// Yoruba Language
		/// </summary>
		[DataMember]
		[Language("yo")]
		public static Language Yoruba { get; set; }

		/// <summary>
		/// Zulu Language
		/// </summary>
		[DataMember]
		[Language("zu")]
		public static Language Zulu { get; set; }


	}
}