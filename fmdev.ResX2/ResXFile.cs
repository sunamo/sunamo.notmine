// <copyright file="ResXFile.cs" company="Florian Mücke">
// Copyright (c) Florian Mücke. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
namespace fmdev.ResX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Design;
    using System.IO;
    using System.Linq;
    using System.Resources;
    using System.Resources.NetStandard;
    using System.Text;
    using System.Threading.Tasks;
    using SunamoExceptions;

    public static class ResXFile
    {
static Type type = typeof(ResXFile);
        [Flags]
        public enum Option
        {
            None = 0,
            SkipComments = 1
        }
        public static List<ResXEntry> Read(string filename, Option options = Option.None)
        {
            var result = new List<ResXEntry>();
            using (var resx = new ResXResourceReader(filename))
            {
                resx.UseResXDataNodes = true;
                var dict = resx.GetEnumerator();
                while (dict.MoveNext())
                {
                    var node = dict.Value as ResXDataNode;
                    var comment = options.HasFlag(Option.SkipComments) ? string.Empty : node.Comment.Replace("\r", string.Empty);
                    result.Add(new ResXEntry()
                    {
                        Id = dict.Key as string,
                        Value = (node.GetValue((ITypeResolutionService)null) as string).Replace("\r", string.Empty),
                        Comment = comment
                    });
                }
                resx.Close();
            }
            return result;
        }
        public static void Write(string filename, IEnumerable<ResXEntry> entries, Option options = Option.None)
        {
            using (var resx = new ResXResourceWriter(filename))
            {
                foreach (var entry in entries)
                {
                    var node = new ResXDataNode(entry.Id, entry.Value.Replace("\r", string.Empty).Replace("\n", Environment.NewLine));
                    if (!options.HasFlag(Option.SkipComments) && !string.IsNullOrWhiteSpace(entry.Comment))
                    {
                        node.Comment = entry.Comment.Replace("\r", string.Empty).Replace("\n", Environment.NewLine);
                    }
                    resx.AddResource(node);
                }
                resx.Close();
            }
        }
        /// <summary>
        /// Generates a public C# designer class.
        /// </summary>
        /// <param name="resXFile">The source resx file.</param>
        /// <param name="className">The base class name.</param>
        /// <param name="namespaceName">The namespace for the generated code.</param>
        /// <returns>false if generation of at least one property couldn't be generated.</returns>
        public static bool GenerateDesignerFile(string resXFile, string className, string namespaceName)
        {
            return GenerateDesignerFile(resXFile, className, namespaceName, false);
        }
        /// <summary>
        /// Generates a C# designer class.
        /// </summary>
        /// <param name="resXFile">The source resx file.</param>
        /// <param name="className">The base class name.</param>
        /// <param name="namespaceName">The namespace for the generated code.</param>
        /// <param name="publicClass">Specifies if the class has public or public access level.</param>
        /// <returns>false if generation of at least one property failed.</returns>
        public static bool GenerateDesignerFile(string resXFile, string className, string namespaceName, bool publicClass)
        {
            if (!File.Exists(resXFile))
            {
                ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),$"The file '{resXFile}' could not be found");
            }
            if (string.IsNullOrEmpty(className))
            {
                ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),$"The class name must not be empty or null");
            }
            if (string.IsNullOrEmpty(namespaceName))
            {
                ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),$"The namespace name must not be empty or null");
            }
            string[] unmatchedElements;
            //System.Resources.Tools.
            var codeProvider = new Microsoft.CSharp.CSharpCodeProvider();
            System.CodeDom.CodeCompileUnit code =
                StronglyTypedResourceBuilder.Create(
                    resXFile,
                    className,
                    namespaceName,
                    codeProvider,
                    publicClass,
                    out unmatchedElements);
            var designerFileName = Path.Combine(Path.GetDirectoryName(resXFile), $"{className}.Designer.cs");
            using (StreamWriter writer = new StreamWriter(designerFileName, false, System.Text.Encoding.UTF8))
            {
                codeProvider.GenerateCodeFromCompileUnit(code, writer, new System.CodeDom.Compiler.CodeGeneratorOptions());
            }
            return unmatchedElements.Length == 0;
        }
    }
}
