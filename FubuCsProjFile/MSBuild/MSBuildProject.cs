﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Versioning;
using System.Text;
using System.Xml;
using FubuCore;
using System.Linq;
using FubuCsProjFile.Templating;

namespace FubuCsProjFile.MSBuild
{
    public class MSBuildProject
    {
        public static MSBuildProject Create(string assemblyName)
        {
            var text = Assembly.GetExecutingAssembly().GetManifestResourceStream(typeof(MSBuildProject), "Project.txt").ReadAllText();

            return create(assemblyName, text);
        }

        private static MSBuildProject create(string assemblyName, string text)
        {
            text = text
                .Replace("FUBUPROJECTNAME", assemblyName);


            var project = new MSBuildProject();
            project.doc = new XmlDocument
            {
                PreserveWhitespace = false
            };

            project.doc.LoadXml(text);

            return project;
        }

        public static MSBuildProject CreateFromFile(string assemblyName, string file)
        {
            var text = TextFile.FileSystem.ReadStringFromFile(file);
            return create(assemblyName, text);
        }

        public static MSBuildProject Parse(string assemblyName, string text)
        {
            return create(assemblyName, text);
        }

        public const string Schema = "http://schemas.microsoft.com/developer/msbuild/2003";
        private static XmlNamespaceManager manager;
        private readonly Dictionary<XmlElement, MSBuildObject> elemCache = new Dictionary<XmlElement, MSBuildObject>();
        private Dictionary<string, MSBuildItemGroup> bestGroups;
        private ByteOrderMark bom;
        public XmlDocument doc;
        private bool endsWithEmptyLine;
        private string newLine = Environment.NewLine;

        public MSBuildProject()
        {
            Settings = MSBuildProjectSettings.DefaultSettings;
            doc = new XmlDocument();
            doc.PreserveWhitespace = false;
            doc.AppendChild(doc.CreateElement(null, "Project", Schema));
        }

        public static XmlNamespaceManager XmlNamespaceManager
        {
            get
            {
                if (manager == null)
                {
                    manager = new XmlNamespaceManager(new NameTable());
                    manager.AddNamespace("tns", Schema);
                }
                return manager;
            }
        }

        public string DefaultTargets
        {
            get { return doc.DocumentElement.GetAttribute("DefaultTargets"); }
            set { doc.DocumentElement.SetAttribute("DefaultTargets", value); }
        }

        public Version ToolsVersion
        {
            get { return new Version(doc.DocumentElement.GetAttribute("ToolsVersion")); }
            set
            {
                if (value != null)
                    doc.DocumentElement.SetAttribute("ToolsVersion", value.ToString());
                else
                    doc.DocumentElement.RemoveAttribute("ToolsVersion");
            }
        }

        public FrameworkName FrameworkName { get { return FrameworkNameDetector.Detect(this); } }

        public MSBuildItemGroup FindGroup(Func<MSBuildItem, bool> itemTest)
        {
            return ItemGroups.FirstOrDefault(x => x.Items.Any(itemTest));
        }

        public MSBuildImport FindImport(Func<MSBuildImport, bool> itemTest)
        {
            return this.ImportsItems.FirstOrDefault(itemTest);
        }

        public List<string> Imports
        {
            get
            {
                var ims = new List<string>();
                foreach (XmlElement elem in doc.DocumentElement.SelectNodes("tns:Import", XmlNamespaceManager))
                {
                    ims.Add(elem.GetAttribute("Project"));
                }
                return ims;
            }
        }

        public IEnumerable<MSBuildPropertyGroup> PropertyGroups
        {
            get
            {
                foreach (XmlElement elem in doc.DocumentElement.SelectNodes("tns:PropertyGroup", XmlNamespaceManager))
                    yield return GetGroup(elem);
            }
        }

        public IEnumerable<MSBuildItemGroup> ItemGroups
        {
            get
            {
                foreach (XmlElement elem in doc.DocumentElement.SelectNodes("tns:ItemGroup", XmlNamespaceManager))
                    yield return GetItemGroup(elem);
            }
        }

        public IEnumerable<MSBuildImport> ImportsItems
        {
            get
            {
                foreach (XmlElement elem in doc.DocumentElement.SelectNodes("tns:Import", XmlNamespaceManager))
                    yield return GetImport(elem);
            }
        }

        public MSBuildProjectSettings Settings { get; set; }

        public IEnumerable<MSBuildTarget> Targets
        {
            get
            {
                foreach (XmlElement elem in doc.DocumentElement.SelectNodes("tns:Target", XmlNamespaceManager))
                    yield return GetTarget(elem);
            }
        }

        public void Load(string file)
        {
            using (FileStream fs = File.OpenRead(file))
            {
                var buf = new byte[1024];
                int nread, i;

                if ((nread = fs.Read(buf, 0, buf.Length)) <= 0)
                    return;

                if (ByteOrderMark.TryParse(buf, nread, out bom))
                    i = bom.Length;
                else
                    i = 0;

                do
                {
                    // Read to the first newline to figure out which line endings this file is using
                    while (i < nread)
                    {
                        if (buf[i] == '\r')
                        {
                            newLine = "\r\n";
                            break;
                        }
                        else if (buf[i] == '\n')
                        {
                            newLine = "\n";
                            break;
                        }

                        i++;
                    }

                    if (newLine == null)
                    {
                        if ((nread = fs.Read(buf, 0, buf.Length)) <= 0)
                        {
                            newLine = "\n";
                            break;
                        }

                        i = 0;
                    }
                } while (newLine == null);

                // Check for a blank line at the end
                endsWithEmptyLine = fs.Seek(-1, SeekOrigin.End) > 0 && fs.ReadByte() == '\n';
            }

            // Load the XML document
            doc = new XmlDocument();
            doc.PreserveWhitespace = false;

            // HACK: XmlStreamReader will fail if the file is encoded in UTF-8 but has <?xml version="1.0" encoding="utf-16"?>
            // To work around this, we load the XML content into a string and use XmlDocument.LoadXml() instead.
            string xml = File.ReadAllText(file);

            doc.LoadXml(xml);
        }

        public void Save(string fileName)
        {
            // StringWriter.Encoding always returns UTF16. We need it to return UTF8, so the
            // XmlDocument will write the UTF8 header.

            if (!this.Settings.MaintainOriginalItemOrder)
            {
                ItemGroups.Each(group =>
                {
                    XmlElement[] elements = null;
                    elements = @group.Items.Select(x => x.Element).OrderBy(x => x.GetAttribute("Include")).ToArray();

                    group.Element.RemoveAll();

                    elements.Each(x => group.Element.AppendChild(x));

                });
            }


            var sw = new ProjectWriter(bom);
            sw.NewLine = newLine;
            doc.Save(sw);

            string content = sw.ToString();
            if (endsWithEmptyLine && !content.EndsWith(newLine))
                content += newLine;

            var shouldSave = !this.Settings.OnlySaveIfChanged ||
                             (File.Exists(fileName) && !File.ReadAllText(fileName).Equals(content));

            if (shouldSave)
                new FileSystem().WriteStringToFile(fileName, content);
        }

        public void AddNewImport(string name, string condition)
        {
            XmlElement elem = doc.CreateElement(null, "Import", Schema);
            elem.SetAttribute("Project", name);

            var last = doc.DocumentElement.SelectSingleNode("tns:Import[last()]", XmlNamespaceManager) as XmlElement;
            if (last != null)
                doc.DocumentElement.InsertAfter(elem, last);
            else
                doc.DocumentElement.AppendChild(elem);
        }

        public void RemoveImport(string name)
        {
            var elem =
                (XmlElement)
                doc.DocumentElement.SelectSingleNode("tns:Import[@Project='" + name + "']", XmlNamespaceManager);
            if (elem != null)
                elem.ParentNode.RemoveChild(elem);
            else
                //FIXME: should this actually log an error?
                Console.WriteLine("ppnf:");
        }

        public MSBuildPropertySet GetGlobalPropertyGroup()
        {
            var res = new MSBuildPropertyGroupMerged();
            foreach (MSBuildPropertyGroup grp in PropertyGroups)
            {
                if (grp.Condition.Length == 0)
                    res.Add(grp);
            }
            return res.GroupCount > 0 ? res : null;
        }

        /// <summary>
        /// Gets the first debug property group matching the supplied <paramref name="platform"/>.
        /// </summary>
        /// <param name="platform">defaults to the global default platform value</param>
        public MSBuildPropertyGroup GetDebugPropertyGroup(string platform = null)
        {
            if (platform == null)
            {
                platform = this.GetGlobalPropertyGroup().GetPropertyValue("Platform");
            }

            return this.PropertyGroups.First(item => item.Condition.Contains(string.Format("{0}|{1}", "Debug", platform), StringComparison.InvariantCultureIgnoreCase));
        }

        /// <summary>
        /// Gets the first release property group matching the supplied <paramref name="platform"/>.
        /// </summary>
        /// <param name="platform">defaults to the global default platform value</param>
        public MSBuildPropertyGroup GetReleasePropertyGroup(string platform = null)
        {
            if (platform == null)
            {
                platform = this.GetGlobalPropertyGroup().GetPropertyValue("Platform");
            }

            return this.PropertyGroups.First(item => item.Condition.Contains(string.Format("{0}|{1}", "Release", platform), StringComparison.InvariantCultureIgnoreCase));
        }

        public MSBuildPropertyGroup AddNewPropertyGroup(bool insertAtEnd)
        {
            XmlElement elem = doc.CreateElement(null, "PropertyGroup", Schema);

            if (insertAtEnd)
            {
                var last =
                    doc.DocumentElement.SelectSingleNode("tns:PropertyGroup[last()]", XmlNamespaceManager) as XmlElement;
                if (last != null)
                    doc.DocumentElement.InsertAfter(elem, last);
            }
            else
            {
                var first = doc.DocumentElement.SelectSingleNode("tns:PropertyGroup", XmlNamespaceManager) as XmlElement;
                if (first != null)
                    doc.DocumentElement.InsertBefore(elem, first);
            }

            if (elem.ParentNode == null)
            {
                var first = doc.DocumentElement.SelectSingleNode("tns:ItemGroup", XmlNamespaceManager) as XmlElement;
                if (first != null)
                    doc.DocumentElement.InsertBefore(elem, first);
                else
                    doc.DocumentElement.AppendChild(elem);
            }

            return GetGroup(elem);
        }

        public MSBuildPropertyGroup AddNewPropertyGroup(MSBuildObject insertAfter)
        {
            XmlElement elem = doc.CreateElement(null, "PropertyGroup", Schema);
            doc.DocumentElement.InsertAfter(elem, insertAfter.Element);

            return GetGroup(elem);
        }

        public IEnumerable<MSBuildItem> GetAllItems()
        {
            foreach (XmlElement elem in doc.DocumentElement.SelectNodes("tns:ItemGroup/*", XmlNamespaceManager))
            {
                yield return GetItem(elem);
            }
        }

        public IEnumerable<MSBuildItem> GetAllItems(params string[] names)
        {
            string name = string.Join("|tns:ItemGroup/tns:", names);
            foreach (
                XmlElement elem in doc.DocumentElement.SelectNodes("tns:ItemGroup/tns:" + name, XmlNamespaceManager))
            {
                yield return GetItem(elem);
            }
        }

        public MSBuildItemGroup AddNewItemGroup()
        {
            XmlElement elem = doc.CreateElement(null, "ItemGroup", Schema);
            doc.DocumentElement.AppendChild(elem);
            return GetItemGroup(elem);
        }

        public MSBuildItem AddNewItem(string name, string include)
        {
            MSBuildItemGroup grp = FindBestGroupForItem(name);
            return grp.AddNewItem(name, include);
        }

        private MSBuildItemGroup FindBestGroupForItem(string itemName)
        {
            MSBuildItemGroup group;

            if (bestGroups == null)
                bestGroups = new Dictionary<string, MSBuildItemGroup>();
            else
            {
                if (bestGroups.TryGetValue(itemName, out group))
                    return group;
            }

            foreach (MSBuildItemGroup grp in ItemGroups)
            {
                foreach (MSBuildItem it in grp.Items)
                {
                    if (it.Name == itemName)
                    {
                        bestGroups[itemName] = grp;
                        return grp;
                    }
                }
            }
            group = AddNewItemGroup();
            bestGroups[itemName] = group;
            return group;
        }

        public string GetProjectExtensions(string section)
        {
            var elem =
                doc.DocumentElement.SelectSingleNode("tns:ProjectExtensions/tns:" + section, XmlNamespaceManager) as
                XmlElement;
            if (elem != null)
                return elem.InnerXml;
            else
                return string.Empty;
        }

        public void SetProjectExtensions(string section, string value)
        {
            XmlElement elem = doc.DocumentElement["ProjectExtensions", Schema];
            if (elem == null)
            {
                elem = doc.CreateElement(null, "ProjectExtensions", Schema);
                doc.DocumentElement.AppendChild(elem);
            }
            XmlElement sec = elem[section];
            if (sec == null)
            {
                sec = doc.CreateElement(null, section, Schema);
                elem.AppendChild(sec);
            }
            sec.InnerXml = value;
        }

        public void RemoveProjectExtensions(string section)
        {
            var elem =
                doc.DocumentElement.SelectSingleNode("tns:ProjectExtensions/tns:" + section, XmlNamespaceManager) as
                XmlElement;
            if (elem != null)
            {
                var parent = (XmlElement)elem.ParentNode;
                parent.RemoveChild(elem);
                if (!parent.HasChildNodes)
                    parent.ParentNode.RemoveChild(parent);
            }
        }

        public void RemoveItem(MSBuildItem item)
        {
            elemCache.Remove(item.Element);
            var parent = (XmlElement)item.Element.ParentNode;
            item.Element.ParentNode.RemoveChild(item.Element);
            if (parent.ChildNodes.Count == 0)
            {
                elemCache.Remove(parent);
                parent.ParentNode.RemoveChild(parent);
                bestGroups = null;
            }
        }

        public MSBuildItem GetItem(XmlElement elem)
        {
            MSBuildObject ob;
            if (elemCache.TryGetValue(elem, out ob))
                return (MSBuildItem)ob;
            var it = new MSBuildItem(elem);
            elemCache[elem] = it;
            return it;
        }

        private MSBuildPropertyGroup GetGroup(XmlElement elem)
        {
            MSBuildObject ob;
            if (elemCache.TryGetValue(elem, out ob))
                return (MSBuildPropertyGroup)ob;
            var it = new MSBuildPropertyGroup(this, elem);
            elemCache[elem] = it;
            return it;
        }

        private MSBuildItemGroup GetItemGroup(XmlElement elem)
        {
            MSBuildObject ob;
            if (elemCache.TryGetValue(elem, out ob))
                return (MSBuildItemGroup)ob;
            var it = new MSBuildItemGroup(this, elem);
            elemCache[elem] = it;
            return it;
        }

        private MSBuildImport GetImport(XmlElement elem)
        {
            MSBuildObject ob;
            if (elemCache.TryGetValue(elem, out ob))
                return (MSBuildImport)ob;
            var it = new MSBuildImport(elem);
            elemCache[elem] = it;
            return it;
        }

        private MSBuildTarget GetTarget(XmlElement elem)
        {
            MSBuildObject ob;
            if (elemCache.TryGetValue(elem, out ob))
                return (MSBuildTarget)ob;
            var it = new MSBuildTarget(elem);
            elemCache[elem] = it;
            return it;
        }

        public void RemoveGroup(MSBuildPropertyGroup grp)
        {
            elemCache.Remove(grp.Element);
            grp.Element.ParentNode.RemoveChild(grp.Element);
        }

        private class ProjectWriter : StringWriter
        {
            private readonly Encoding encoding;

            public ProjectWriter(ByteOrderMark bom)
            {
                encoding = bom != null ? Encoding.GetEncoding(bom.Name) : null;
                ByteOrderMark = bom;
            }

            public ByteOrderMark ByteOrderMark { get; private set; }

            public override Encoding Encoding
            {
                get { return encoding ?? Encoding.UTF8; }
            }
        }

        public static MSBuildProject LoadFrom(string fileName)
        {
            var project = new MSBuildProject();
            project.Load(fileName);

            return project;
        }
    }
}