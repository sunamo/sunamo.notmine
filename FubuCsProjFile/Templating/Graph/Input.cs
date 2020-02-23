using System.Collections.Generic;
using System.Linq;
using FubuCore;

namespace FubuCsProjFile.Templating.Graph
{
    public class Input
    {
        public static readonly string File = "inputs.txt";

        public Input()
        {
        }

        public Input(string text)
        {
            List<string> parts = new List<string>( text.ToDelimitedArray());
            if (parts.First().Contains("="))
            {
                List<string> nameParts = parts.First().Split('=').ToList();
                Name = nameParts.First();
                Default = nameParts.Last();
            }
            else
            {
                Name = parts.First();
            }

            Description = parts.Last();
        }

        public string Name { get; set; }
        public string Default { get; set; }
        public string Description { get; set; }

        public static IEnumerable<Input> ReadFrom(string directory)
        {
            var fileSystem = new FileSystem();
            string file = directory.AppendPath(File);
            if (!fileSystem.FileExists(file))
            {
                return Enumerable.Empty<Input>();
            }

            return ReadFromFile(file);
        }

        public static IEnumerable<Input> ReadFromFile(string file)
        {
            return new FileSystem().ReadStringFromFile(file).ReadLines().Where(x => x.IsNotEmpty())
                             .Select(x => new Input(x)).ToArray();
        }
    }
}