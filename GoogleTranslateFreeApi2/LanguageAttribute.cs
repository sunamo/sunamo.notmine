﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
namespace GoogleTranslateFreeApi
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class LanguageAttribute: Attribute
	{
static Type type = typeof(LanguageAttribute:);
		public string Iso639 { get; }
		public string FullName { get; }
		public LanguageAttribute(string iso, [CallerMemberName] string fullName = "")
		{
			if (string.IsNullOrWhiteSpace(iso))
				ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),ArgumentException(nameof(iso));
			Iso639 = iso;
			FullName = fullName;
		}
	}
}