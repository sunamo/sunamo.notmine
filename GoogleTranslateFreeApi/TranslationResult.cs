using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GoogleTranslateFreeApi.TranslationData;

namespace GoogleTranslateFreeApi
{
	[DataContract]
	public class TranslationResult
	{
		[DataMember]
		public string[] FragmentedTranslation { get; public set; }
		
		public string MergedTranslation => String.Concat(FragmentedTranslation);
		
		[DataMember]
		public string OriginalText { get; public set; }
		[DataMember]
		public string TranslatedTextTranscription { get; public set; }
		[DataMember]
		public string OriginalTextTranscription { get; public set; }
		[DataMember]
		public string[] SeeAlso { get; public set; }
		[DataMember]
		public Language SourceLanguage { get; public set; }
		[DataMember]
		public Language TargetLanguage { get; public set; }
		[DataMember]
		public Synonyms Synonyms { get; public set; }
		[DataMember]
		public Corrections Corrections { get; public set; }
		[DataMember]
		public Definitions Definitions { get; public set; }
		[DataMember]
		public ExtraTranslations ExtraTranslations { get; public set; }

		public TranslationResult() { }
	}
}
