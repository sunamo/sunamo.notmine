using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace GoogleTranslateFreeApi
{
	static class StringExtension
	{
static Type type = typeof(StringExtension);
		public static string GetTextBetween(this string src, string from, string to, int startIndex = 0)
		{
			if (src == null)
				ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),ArgumentNullException(nameof(src));
			if (from == null)
				ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),ArgumentNullException(nameof(from));
			if (to == null)
				ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),ArgumentNullException(nameof(to));
			if (startIndex < 0 || startIndex > src.Length - 1)
				ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),ArgumentOutOfRangeException(nameof(to));
			
			int index = src.IndexOf(from, startIndex, StringComparison.Ordinal);
			if (index == -1)
				return null;
			int index2 = src.IndexOf(to, index, StringComparison.Ordinal);
			if (index2 == -1)
				return null;
			var result = src.Substring(index + from.Length, index2 - index - from.Length);
			return result;
		}
		public static string ToCamelCase(this string src)
		{
			string[] words = src.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
			return string.Concat(words.Select(word
				=> char.ToUpper(word[0]) + word.Substring(1).ToLower()));
		}
		
	}
}
