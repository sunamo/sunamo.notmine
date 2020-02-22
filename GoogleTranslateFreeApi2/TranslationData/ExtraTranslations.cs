using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace GoogleTranslateFreeApi.TranslationData
{
	[DataContract]
	public sealed class ExtraTranslations : TranslationInfoParser
	{
		[DataContract]
		public sealed class ExtraTranslation
		{
			[DataMember] public string Phrase { get; private set; }
			[DataMember] public List<string> PhraseTranslations { get; private set; }

			public ExtraTranslation(string phrase, List<string> phraseTranslations)
			{
				Phrase = phrase;
				PhraseTranslations = phraseTranslations;
			}

			public override string ToString() => $"{Phrase}: {String.Join(", ", PhraseTranslations)}";
		}
		
		[DataMember] public ExtraTranslation[] Noun { get; set; }
		[DataMember] public ExtraTranslation[] Verb { get; set; }
		[DataMember] public ExtraTranslation[] Pronoun { get;   set; }
		[DataMember] public ExtraTranslation[] Adverb { get; set; }
		[DataMember] public ExtraTranslation[] AuxiliaryVerb { get; set; }
		[DataMember] public ExtraTranslation[] Adjective { get; set; }
		[DataMember] public ExtraTranslation[] Conjunction { get; set; }
		[DataMember] public ExtraTranslation[] Preposition { get; set; }
		[DataMember] public ExtraTranslation[] Interjection { get; set; }
		[DataMember] public ExtraTranslation[] Suffix { get; set; }
		[DataMember] public ExtraTranslation[] Prefix { get; set; }
		[DataMember] public ExtraTranslation[] Abbreviation { get; set; }
		[DataMember] public ExtraTranslation[] Particle { get; set; }
		[DataMember] public ExtraTranslation[] Phrase { get; set; }
		
		public ExtraTranslations() { }

		
		private string FormatOutput(IEnumerable<ExtraTranslation> formatData, string partOfSpeechName)
		{
			if(formatData == null)
				return String.Empty;
			
			string result = partOfSpeechName + ":\n";

			return formatData.Aggregate(result, (current, data) 
				=> current + $"{data.Phrase}: {String.Join(", ", data.PhraseTranslations)}\n");
		}

		public override string ToString()
		{
			string result = String.Empty;
			
			result += FormatOutput(Noun, nameof(Noun));
			result += FormatOutput(Verb, nameof(Verb));
			result += FormatOutput(Pronoun, nameof(Pronoun));
			result += FormatOutput(Adverb, nameof(Adverb));
			result += FormatOutput(AuxiliaryVerb, nameof(AuxiliaryVerb));
			result += FormatOutput(Adjective, nameof(Adjective));
			result += FormatOutput(Conjunction, nameof(Conjunction));
			result += FormatOutput(Preposition, nameof(Preposition));
			result += FormatOutput(Interjection, nameof(Interjection));
			result += FormatOutput(Suffix, nameof(Suffix));
			result += FormatOutput(Prefix, nameof(Prefix));
			result += FormatOutput(Abbreviation, nameof(Abbreviation));
			result += FormatOutput(Particle, nameof(Particle));
			result += FormatOutput(Phrase, nameof(Phrase));

			return result.Trim();
		}


		public override bool TryParseMemberAndAdd(string memberName, JToken parseInformation)
		{
			PropertyInfo property = this.GetType().GetRuntimeProperty(memberName.ToCamelCase());
			if (property == null)
				return false;
			
			var extraTranslations = new ExtraTranslation[parseInformation.Count()];

			for (int i = 0; i < parseInformation.Count(); i++)
				extraTranslations[i] = new ExtraTranslation(
					(string) parseInformation[i][0], parseInformation[i][1].ToObject<List<string>>());

			property.SetMethod.Invoke(this,
				new object[] { extraTranslations } );

			return true;
		}

		public override int ItemDataIndex => 2;
	}
}
