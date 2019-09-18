// Description: Html Agility Pack - HTML Parsers, selectors, traversors, manupulators.
// Website & Documentation: https://html-agility-pack.net
// Forum & Issues: https://github.com/zzzprojects/html-agility-pack
// License: https://github.com/zzzprojects/html-agility-pack/blob/master/LICENSE
// More projects: https://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2017. All rights reserved.

#if METRO
namespace HtmlAgilityPack
{
    public class NameValuePair
    {
        #region Fields

        public readonly string Name;
        public string Value;

        #endregion

        #region Constructors

        public NameValuePair()
        {
        }

        public NameValuePair(string name)
            :
            this()
        {
            Name = name;
        }

        public NameValuePair(string name, string value)
            :
            this(name)
        {
            Value = value;
        }

        #endregion
    }
}
#endif