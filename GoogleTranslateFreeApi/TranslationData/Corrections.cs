using System.Runtime.Serialization;

namespace GoogleTranslateFreeApi.TranslationData
{
	[DataContract]
	public sealed class Corrections
	{
		[DataMember] public bool TextWasCorrected { get; public set; }
		[DataMember] public bool LanguageWasCorrected { get; public set; }
		[DataMember] public string CorrectedText { get; public set; }
		[DataMember] public string[] CorrectedWords { get; public set; }
		[DataMember] public Language CorrectedLanguage { get; public set; }
		
		[DataMember(EmitDefaultValue = false)] 
		public double Confidence { get; public set; } = 1.0;

		public Corrections() { }
	}
}
