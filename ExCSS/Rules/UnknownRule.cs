﻿using System.IO;

namespace ExCSS
{
    public sealed class UnknownRule : Rule
    {
        public UnknownRule(string name, StylesheetParser parser)
            : base(RuleType.Unknown, parser)
        {
            Name = name;
        }

        public string Name { get; }

        public override void ToCss(TextWriter writer, IStyleFormatter formatter)
        {
            writer.Write(StylesheetText?.Text);
        }
    }
}