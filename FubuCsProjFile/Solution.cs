using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using FubuCore;
using System.Linq;
using FubuCore.Util;
using FubuCsProjFile.MSBuild;

namespace FubuCsProjFile
{
    public class Solution
    {
        private const string Global = "Global";
        private const string EndGlobal = "EndGlobal";
        public const string EndGlobalSection = "EndGlobalSection";
        public const string EndProjectSection = "EndProjectSection";
        private const string SolutionConfigurationPlatforms = "SolutionConfigurationPlatforms";
        private const string ProjectConfigurationPlatforms = "ProjectConfigurationPlatforms";

        public static readonly Guid SolutionFolderId = new Guid("2150E333-8FDC-42A3-9474-1A3956D46DE8");
        
        public static readonly string VS2010 = "VS2010";
        public static readonly string VS2012 = "VS2012";
        public static readonly string VS2013 = "VS2013";
        public static readonly string DefaultVersion = VS2010;

        private static readonly Cache<string, List<string>> _versionLines = new Cache<string, List<string>>();

        static Solution()
        {
            _versionLines[VS2010] = new List<string> { "Microsoft Visual Studio Solution File, Format Version 11.00", "# Visual Studio 2010" };
            _versionLines[VS2012] = new List<string> { "Microsoft Visual Studio Solution File, Format Version 12.00", "# Visual Studio 2012" };
            _versionLines[VS2013] = new List<string> { "Microsoft Visual Studio Solution File, Format Version 12.00", "# Visual Studio 2013", "VisualStudioVersion = 12.0.21005.1", "MinimumVisualStudioVersion = 10.0.40219.1" };
        }

        private readonly string _filename;
        private readonly IList<SolutionProject> _projects = new List<SolutionProject>(); 
        protected readonly IList<string> _header = new List<string>(); 
        /// <summary>
        /// Creates a new empty Solution file with the supplied name that
        /// will be written to the directory given upon calling Save()
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="name"></param>
        
        public SolutionProject FindProject(string projectName)
        {
            return _projects.FirstOrDefault(x => x.ProjectName == projectName);
        }

        public override string ToString()
        {
            return string.Format("{0}", this.Filename);
        }
    }
}