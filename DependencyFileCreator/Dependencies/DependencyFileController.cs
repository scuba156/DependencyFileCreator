using DependencyChecker.Dependencies;
using DependencyChecker.Dependencies.SupportedFiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace DependencyFileCreator.Dependencies {

    internal static class DependencyFileController {

        public static List<DependencyMetaData> LoadFromFile(string rootDir) {
            DependenciesFile file = DependenciesFile.TryParseFile(rootDir);
            if (file == null) {
                return new List<DependencyMetaData>();
            }
            return file.Dependencies;
        }

        public static void SaveToFile(string filePath, List<DependencyMetaData> dependencies) {
            XDocument doc = new XDocument();
            XElement rootElement = new XElement("Dependencies");

            foreach (var dependency in dependencies) {
                string verString;
                if (dependency.RequiredVersion == new Version()) {
                    verString = string.Empty;
                } else {
                    verString = dependency.RequiredVersion.ToString();
                }
                XElement dependencyElement = new XElement("Dependency",
                    new XElement("Identifier", dependency.Identifier),
                    new XElement("SteamID", dependency.SteamID),
                    new XElement("RequiredVersion", verString)
                    );
                rootElement.Add(dependencyElement);
            }

            doc.Add(rootElement);
            doc.Save(Path.Combine(filePath, DependenciesFile.RelativePath));
        }
    }
}