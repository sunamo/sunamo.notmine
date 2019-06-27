using System.Runtime.Serialization;

namespace GoogleTranslateFreeApi.TranslationData
{
	[DataContract]
	public sealed class Corrections
	{
		[DataMember] public bool TextWasCorrected { get; set; }
		[DataMember] public bool LanguageWasCorrected { get; set; }
		[DataMember] public string CorrectedText { get; set; }
		[DataMember] public string[] CorrectedWords { get; set; }
		[DataMember] public Language CorrectedLanguage { get; set; }
		
		[DataMember(EmitDefaultValue = false)] 
		public double Confidence { get; set; } = 1.0;

		public Corrections() { }
	}
}
