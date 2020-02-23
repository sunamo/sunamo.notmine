using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Win32;

namespace PathEditor.Models
{
    public class PathRepository
    {
        private const string PathKeyName = @"SYSTEM\CurrentControlSet\Control\Session Manager\Environment\";

        public List<string> GetPathParts()
        {
            return ((string)Registry.LocalMachine.OpenSubKey(PathKeyName).GetValue("Path", string.Empty, RegistryValueOptions.DoNotExpandEnvironmentNames))
                .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                .OrderBy(p => p)
                .ToList();
        }

        public void SetPathFromParts(List<string> pathParts)
        {
            var paths = pathParts
                .Where(p => !string.IsNullOrWhiteSpace(p))
                .Where(p => Directory.Exists(Environment.ExpandEnvironmentVariables(p)))
                .Distinct(StringComparer.OrdinalIgnoreCase);

            var path = string.Join(";", paths);

            Environment.SetEnvironmentVariable("Path", path, EnvironmentVariableTarget.Machine);
        }
    }
}
