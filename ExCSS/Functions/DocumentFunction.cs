using System.IO;

namespace ExCSS
{
    public abstract class DocumentFunction : StylesheetNode, IDocumentFunction
    {
        public DocumentFunction(string name, string data)
        {
            Name = name;
            Data = data;
        }

        public override void ToCss(TextWriter writer, IStyleFormatter formatter)
        {
            writer.Write(Name.StylesheetFunction(Data.StylesheetString()));
        }

        public string Name { get; }
        public string Data { get; }
        public abstract bool Matches(Url url);

    }
}