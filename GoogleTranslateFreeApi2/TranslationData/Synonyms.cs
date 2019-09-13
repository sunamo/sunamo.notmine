using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using Newtonsoft.Json.Linq;

namespace GoogleTranslateFreeApi.TranslationData
{
	[DataContract]
	public sealed class Synonyms: TranslationInfoParser
	{
		[DataMember] public string[] Noun { get; set; }
		[DataMember] public string[] Exclamation { get; set; }
		[DataMember] public string[] Adjective { get; set; }
		[DataMember] public string[] Verb { get; set; }
		[DataMember] public string[] Adverb { get; set; }
		[DataMember] public string[] Preposition { get; set; }
		[DataMember] public string[] Conjunction { get; set; }
		[DataMember] public string[] Pronoun { get; set; }

		public Synonyms() { }

		public override string ToString()
		{
			string info = String.Empty;
			info += FormatOutput(Noun, nameof(Noun));
			info += FormatOutput(Verb, nameof(Verb));
			info += FormatOutput(Pronoun, nameof(Pronoun));
			info += FormatOutput(Adverb, nameof(Adverb));
			info += FormatOutput(Adjective, nameof(Adjective));
			info += FormatOutput(Conjunction, nameof(Conjunction));
			info += FormatOutput(Preposition, nameof(Preposition));
			info += FormatOutput(Exclamation, nameof(Exclamation));

			return info.TrimEnd();
		}

		private string FormatOutput(IEnumerable<string> partOfSpeechData, string partOfSpeechName)
		{
			if (partOfSpeechData == null)
				return String.Empty;

			return !partOfSpeechData.Any()
				? String.Empty
				: $"{partOfSpeechName}: {string.Join(", ", partOfSpeechData)} \n";
		}

		public override bool TryParseMemberAndAdd(string memberName, JToken parseInformation)
		{
			PropertyInfo property = this.GetType().GetRuntimeProperty(memberName.ToCamelCase());
			if (property == null)
				return false;
			
			List<string> synonyms = new List<string>();
			foreach (var synonymsSet in parseInformation)
				synonyms.AddRange(synonymsSet[0].ToObject<string[]>());
			
			property.SetMethod.Invoke(this, new object[] { synonyms.ToArray() });
			
			return true;
		}

		public override int ItemDataIndex => 1;
	}
}
