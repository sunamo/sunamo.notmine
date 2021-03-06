﻿using System;
using Newtonsoft.Json.Linq;

namespace GoogleTranslateFreeApi.TranslationData
{
  public abstract class TranslationInfoParser
  {
    public abstract bool TryParseMemberAndAdd(string memberName, JToken parseInformation);
    public abstract int ItemDataIndex { get; }
    ////////////////////////////////////////////////////////////////////////////////////////////
    //I've created a method, because the where: new() statement requires a public constructor///
    ////////////////////////////////////////////////////////////////////////////////////////////    
    public static T Create<T>() where T : TranslationInfoParser
    {
      Type type = typeof(T);

      if (type == typeof(ExtraTranslations))
        return new ExtraTranslations() as T;
      if (type == typeof(Definitions))
        return new Definitions() as T;
      if (type == typeof(Synonyms))
        return new Synonyms() as T;

      ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),NotSupportedException("type");
    }
  }
}