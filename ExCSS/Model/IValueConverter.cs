﻿using System.Collections.Generic;

namespace ExCSS
{
    public interface IValueConverter
    {
        IPropertyValue Convert(IEnumerable<Token> value);
        IPropertyValue Construct(Property[] properties);
    }

    public static class PropertyExtensions
    {
        public static IPropertyValue Guard<T>(this Property[] properties)
        {
            if (properties.Length != 1)
            {
                return null;
            }

            var value = properties[0].DeclaredValue;
            return value is T ? properties[0].DeclaredValue : null;
        }
    }
}