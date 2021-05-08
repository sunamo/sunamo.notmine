﻿// Copyright (c) Jeff Kluge. All rights reserved.
//
// Licensed under the MIT license.
using Microsoft.Build.Evaluation;
using Microsoft.Build.Framework;
using SunamoExceptions;
using System;
using System.Collections.Generic;
using System.IO;
namespace SlnGen.Common
{
    public sealed class SlnProject
    {
static Type type = typeof(SlnProject);
        public static readonly Guid DefaultLegacyProjectTypeGuid = new Guid("FAE04EC0-301F-11D3-BF4B-00C04F79EFBC");
        public static readonly Guid DefaultNetSdkProjectTypeGuid = new Guid("9A19103F-16F7-4668-BE54-9A1E7A4F7556");
        /// <summary>
        /// Known project type GUIDs for legacy projects.
        /// </summary>
        public static readonly IReadOnlyDictionary<string, Guid> KnownLegacyProjectTypeGuids = new Dictionary<string, Guid>(StringComparer.OrdinalIgnoreCase)
        {
            [string.Empty] = DefaultLegacyProjectTypeGuid,
            [".csproj"] = DefaultLegacyProjectTypeGuid,
            [".vbproj"] = new Guid("F184B08F-C81C-45F6-A57F-5ABD9991F28F"),
        };
        /// <summary>
        /// Known project type GUIDs for .NET SDK projects.
        /// </summary>
        public static readonly IReadOnlyDictionary<string, Guid> KnownNetSdkProjectTypeGuids = new Dictionary<string, Guid>(StringComparer.OrdinalIgnoreCase)
        {
            [string.Empty] = DefaultNetSdkProjectTypeGuid,
            [".csproj"] = DefaultNetSdkProjectTypeGuid,
            [".vbproj"] = new Guid("778DAE3C-4631-46EA-AA77-85C1314464D9"),
        };
        /// <summary>
        /// Known project type GUIDs for all project types.
        /// </summary>
        public static readonly IReadOnlyDictionary<string, Guid> KnownProjectTypeGuids = new Dictionary<string, Guid>(StringComparer.OrdinalIgnoreCase)
        {
            [".ccproj"] = new Guid("151D2E53-A2C4-4D7D-83FE-D05416EBD58E"),
            [".fsproj"] = new Guid("F2A71F9B-5D33-465A-A702-920D77279786"),
            [".nativeProj"] = new Guid("8BC9CEB8-8B4A-11D0-8D11-00A0C91BC942"),
            [".nuproj"] = new Guid("FF286327-C783-4F7A-AB73-9BCBAD0D4460"),
            [".vcproj"] = new Guid("8BC9CEB8-8B4A-11D0-8D11-00A0C91BC942"),
            [".vcxproj"] = new Guid("8BC9CEB8-8B4A-11D0-8D11-00A0C91BC942"),
            [".vjsproj"] = new Guid("E6FDF86B-F3D1-11D4-8576-0002A516ECE8"),
            [".wixproj"] = new Guid("930C7802-8A8C-48F9-8165-68863BCCD9DD"),
            [".sfproj"] = new Guid("A07B5EB6-E848-4116-A8D0-A826331D98C6"),
        };
        public SlnProject(string fullPath, string name, Guid projectGuid, Guid projectTypeGuid, IEnumerable<string> configurations, IEnumerable<string> platforms, bool isMainProject, bool isDeployable)
        {
            
            ThrowExceptions.IsNull(Exc.GetStackTrace(), type, Exc.CallingMethod(), nameof(fullPath));
            ThrowExceptions.IsNull(Exc.GetStackTrace(), type, Exc.CallingMethod(), nameof(name));
            ProjectGuid = projectGuid;
            ProjectTypeGuid = projectTypeGuid;
            IsDeployable = isDeployable;
            IsMainProject = isMainProject;
            Configurations = new HashSet<string>(configurations, StringComparer.OrdinalIgnoreCase);
            Platforms = new HashSet<string>(platforms, StringComparer.OrdinalIgnoreCase);
        }
        public HashSet<string> Configurations { get; }
        public string FullPath { get; }
        public bool IsDeployable { get; }
        public bool IsMainProject { get; }
        public string Name { get; }
        public HashSet<string> Platforms { get; }
        public Guid ProjectGuid { get; }
        public Guid ProjectTypeGuid { get; }
        public static SlnProject FromProject(Project project, IReadOnlyDictionary<string, Guid> customProjectTypeGuids, bool isMainProject = false)
        {
            if (project == null)
            {
                ThrowExceptions.IsNull(Exc.GetStackTrace(), type, Exc.CallingMethod(),nameof(project));
            }
            if (customProjectTypeGuids == null)
            {
                ThrowExceptions.IsNull(Exc.GetStackTrace(), type, Exc.CallingMethod(),nameof(customProjectTypeGuids));
            }
            if (!ShouldIncludeInSolution(project))
            {
                return null;
            }
            string name = project.GetPropertyValueOrDefault(SlnConstants.AssemblyName, Path.GetFileNameWithoutExtension(project.FullPath));
            bool isUsingMicrosoftNetSdk = project.GetPropertyValue(SlnConstants.UsingMicrosoftNETSdk).Equals("true", StringComparison.OrdinalIgnoreCase);
            string extension = Path.GetExtension(project.FullPath);
            Guid projectTypeGuid = GetKnownProjectTypeGuid(extension, isUsingMicrosoftNetSdk, customProjectTypeGuids);
            IEnumerable<string> configurations = project.GetPossiblePropertyValuesOrDefault("Configuration", "Debug");
            IEnumerable<string> platforms = GetPlatforms(project);
            Guid projectGuid = Guid.NewGuid();
            if (!isUsingMicrosoftNetSdk && !Guid.TryParse(project.GetPropertyValueOrDefault(SlnConstants.ProjectGuid, projectGuid.ToString()), out projectGuid))
            {
                ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),$"property ProjectGuid has an invalid format in {project.FullPath}");
            }
            string isDeployableStr = project.GetPropertyValue("SlnGenIsDeployable");
            bool isDeployable = isDeployableStr.Equals("true", StringComparison.OrdinalIgnoreCase) || (string.IsNullOrWhiteSpace(isDeployableStr) && string.Equals(Path.GetExtension(project.FullPath), ".sfproj", StringComparison.OrdinalIgnoreCase));
            return new SlnProject(project.FullPath, name, projectGuid, projectTypeGuid, configurations, platforms, isMainProject, isDeployable);
        }
        public static Dictionary<string, Guid> GetCustomProjectTypeGuids(IEnumerable<ITaskItem> items)
        {
            Dictionary<string, Guid> projectTypeGuids = new Dictionary<string, Guid>();
            foreach (ITaskItem taskItem in items)
            {
                string extension = taskItem.ItemSpec.Trim();
                // Only consider items that start with a "." because they are supposed to be file extensions
                if (!extension.StartsWith("."))
                {
                    continue;
                }
                string projectTypeGuidString = taskItem.GetMetadata(SlnConstants.ProjectTypeGuid)?.Trim();
                if (!string.IsNullOrWhiteSpace(projectTypeGuidString) && Guid.TryParse(projectTypeGuidString, out Guid projectTypeGuid))
                {
                    // Trim and ToLower the file extension
                    projectTypeGuids[taskItem.ItemSpec.Trim().ToLowerInvariant()] = projectTypeGuid;
                }
            }
            return projectTypeGuids;
        }
        /// <summary>
        /// Determines the project type GUID for the specified file extension.
        /// </summary>
        /// <param name="extension">The file extension of the project.</param>
        /// <param name="isUsingMicrosoftNetSdk">Indicates whether or not the project is using the Microsoft.NET.Sdk.</param>
        /// <param name="customProjectTypeGuids">A list of custom project type GUIDs to use.</param>
        /// <returns>The project type GUID for the specfied project extension.</returns>
        public static Guid GetKnownProjectTypeGuid(string extension, bool isUsingMicrosoftNetSdk, IReadOnlyDictionary<string, Guid> customProjectTypeGuids)
        {
            if (customProjectTypeGuids.TryGetValue(extension, out Guid projectTypeGuid) || KnownProjectTypeGuids.TryGetValue(extension, out projectTypeGuid))
            {
                return projectTypeGuid;
            }
            // Use GUIDs for .NET SDK projects
            if (isUsingMicrosoftNetSdk && !KnownNetSdkProjectTypeGuids.TryGetValue(extension, out projectTypeGuid))
            {
                projectTypeGuid = DefaultNetSdkProjectTypeGuid;
            }
            // Use GUIDs for legacy projects
            if (!isUsingMicrosoftNetSdk && !KnownLegacyProjectTypeGuids.TryGetValue(extension, out projectTypeGuid))
            {
                projectTypeGuid = DefaultLegacyProjectTypeGuid;
            }
            return projectTypeGuid;
        }
        /// <summary>
        /// Checks whether a project should be included in the solution or not.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns><code>true</code> if it should be included, <code>false</code> otherwise.</returns>
        public static bool ShouldIncludeInSolution(Project project)
        {
            return
                !project.GetPropertyValue(SlnConstants.IncludeInSolutionFile).Equals(bool.FalseString, StringComparison.OrdinalIgnoreCase) // Filter out projects that explicitly should not be included
                &&
                !project.GetPropertyValue(SlnConstants.IsTraversal).Equals(bool.TrueString, StringComparison.OrdinalIgnoreCase);  // Filter out traversal projects by looking for an IsTraversal property
        }
        private static IEnumerable<string> GetPlatforms(Project project)
        {
            foreach (string platform in project.GetPossiblePropertyValuesOrDefault("Platform", "Any CPU"))
            {
                if (string.Equals(platform, "AnyCPU", StringComparison.OrdinalIgnoreCase))
                {
                    yield return "Any CPU";
                }
                else
                {
                    yield return platform;
                }
            }
        }
    }
}