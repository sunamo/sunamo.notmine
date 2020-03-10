// Description: Html Agility Pack - HTML Parsers, selectors, traversors, manupulators.
// Website & Documentation: https://html-agility-pack.net
// Forum & Issues: https://github.com/zzzprojects/html-agility-pack
// License: https://github.com/zzzprojects/html-agility-pack/blob/master/LICENSE
// More projects: https://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2017. All rights reserved.
#if !METRO
using System;
using System.IO;
using System.Text;
using SunamoExceptions;
namespace HtmlAgilityPack
{
    public partial class HtmlDocument
    {
static Type type = typeof(HtmlDocument);
        /// <summary>
        /// Detects the encoding of an HTML document from a file first, and then loads the file.
        /// </summary>
        /// <param name="path">The complete file path to be read.</param>
        public void DetectEncodingAndLoad(string path)
        {
            DetectEncodingAndLoad(path, true);
        }
        /// <summary>
        /// Detects the encoding of an HTML document from a file first, and then loads the file.
        /// </summary>
        /// <param name="path">The complete file path to be read. May not be null.</param>
        /// <param name="detectEncoding">true to detect encoding, false otherwise.</param>
        public void DetectEncodingAndLoad(string path, bool detectEncoding)
        {
            if (path == null)
            {
                ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"path");
            }
            Encoding enc;
            if (detectEncoding)
            {
                enc = DetectEncoding(path);
            }
            else
            {
                enc = null;
            }
            if (enc == null)
            {
                Load(path);
            }
            else
            {
                Load(path, enc);
            }
        }
        /// <summary>
        /// Detects the encoding of an HTML file.
        /// </summary>
        /// <param name="path">Path for the file containing the HTML document to detect. May not be null.</param>
        /// <returns>The detected encoding.</returns>
        public Encoding DetectEncoding(string path)
        {
            if (path == null)
            {
                ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"path");
            }
#if NETSTANDARD1_3 || NETSTANDARD1_6
            using (StreamReader sr = new StreamReader(File.OpenRead(path), OptionDefaultStreamEncoding))
#else
            using (StreamReader sr = new StreamReader(path, OptionDefaultStreamEncoding))
#endif
            {
                Encoding encoding = DetectEncoding(sr);
                return encoding;
            }
        }
        /// <summary>
        /// Loads an HTML document from a file.
        /// </summary>
        /// <param name="path">The complete file path to be read. May not be null.</param>
        public void Load(string path)
        {
            if (path == null)
                ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"path");
#if NETSTANDARD1_3 || NETSTANDARD1_6
            using (StreamReader sr = new StreamReader(File.OpenRead(path), OptionDefaultStreamEncoding))
#else
            using (StreamReader sr = new StreamReader(path, OptionDefaultStreamEncoding))
#endif
            {
                Load(sr);
            }
        }
        /// <summary>
        /// Loads an HTML document from a file.
        /// </summary>
        /// <param name="path">The complete file path to be read. May not be null.</param>
        /// <param name="detectEncodingFromByteOrderMarks">Indicates whether to look for byte order marks at the beginning of the file.</param>
        public void Load(string path, bool detectEncodingFromByteOrderMarks)
        {
            if (path == null)
                ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"path");
#if NETSTANDARD1_3 || NETSTANDARD1_6
            using (StreamReader sr = new StreamReader(File.OpenRead(path), detectEncodingFromByteOrderMarks))
#else
            using (StreamReader sr = new StreamReader(path, detectEncodingFromByteOrderMarks))
#endif
            {
                Load(sr);
            }
        }
        /// <summary>
        /// Loads an HTML document from a file.
        /// </summary>
        /// <param name="path">The complete file path to be read. May not be null.</param>
        /// <param name="encoding">The character encoding to use. May not be null.</param>
        public void Load(string path, Encoding encoding)
        {
            if (path == null)
                ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"path");
            if (encoding == null)
                ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"encoding");
#if NETSTANDARD1_3 || NETSTANDARD1_6
            using (StreamReader sr = new StreamReader(File.OpenRead(path), encoding))
#else
            using (StreamReader sr = new StreamReader(path, encoding))
#endif
            {
                Load(sr);
            }
        }
        /// <summary>
        /// Loads an HTML document from a file.
        /// </summary>
        /// <param name="path">The complete file path to be read. May not be null.</param>
        /// <param name="encoding">The character encoding to use. May not be null.</param>
        /// <param name="detectEncodingFromByteOrderMarks">Indicates whether to look for byte order marks at the beginning of the file.</param>
        public void Load(string path, Encoding encoding, bool detectEncodingFromByteOrderMarks)
        {
            if (path == null)
                ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"path");
            if (encoding == null)
                ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"encoding");
#if NETSTANDARD1_3 || NETSTANDARD1_6
            using (StreamReader sr = new StreamReader(File.OpenRead(path), encoding, detectEncodingFromByteOrderMarks))
#else
            using (StreamReader sr = new StreamReader(path, encoding, detectEncodingFromByteOrderMarks))
#endif
            {
                Load(sr);
            }
        }
        /// <summary>
        /// Loads an HTML document from a file.
        /// </summary>
        /// <param name="path">The complete file path to be read. May not be null.</param>
        /// <param name="encoding">The character encoding to use. May not be null.</param>
        /// <param name="detectEncodingFromByteOrderMarks">Indicates whether to look for byte order marks at the beginning of the file.</param>
        /// <param name="buffersize">The minimum buffer size.</param>
        public void Load(string path, Encoding encoding, bool detectEncodingFromByteOrderMarks, int buffersize)
        {
            if (path == null)
                ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"path");
            if (encoding == null)
                ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"encoding");
#if NETSTANDARD1_3 || NETSTANDARD1_6
            using (StreamReader sr = new StreamReader(File.OpenRead(path), encoding, detectEncodingFromByteOrderMarks, buffersize))
#else
            using (StreamReader sr = new StreamReader(path, encoding, detectEncodingFromByteOrderMarks, buffersize))
#endif
            {
                Load(sr);
            }
        }
        /// <summary>
        /// Saves the mixed document to the specified file.
        /// </summary>
        /// <param name="filename">The location of the file where you want to save the document.</param>
        public void Save(string filename)
        {
#if NETSTANDARD1_3 || NETSTANDARD1_6
            using (StreamWriter sw = new StreamWriter(File.OpenWrite(filename), GetOutEncoding()))
#else
            using (StreamWriter sw = new StreamWriter(filename, false, GetOutEncoding()))
#endif
            {
                Save(sw);
            }
        }
        /// <summary>
        /// Saves the mixed document to the specified file.
        /// </summary>
        /// <param name="filename">The location of the file where you want to save the document. May not be null.</param>
        /// <param name="encoding">The character encoding to use. May not be null.</param>
        public void Save(string filename, Encoding encoding)
        {
            if (filename == null)
            {
                ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"filename");
            }
            if (encoding == null)
            {
                ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"encoding");
            }
#if NETSTANDARD1_3 || NETSTANDARD1_6
            using (StreamWriter sw = new StreamWriter(File.OpenWrite(filename), encoding))
#else
            using (StreamWriter sw = new StreamWriter(filename, false, encoding))
#endif
            {
                Save(sw);
            }
        }
    }
}
#endif
