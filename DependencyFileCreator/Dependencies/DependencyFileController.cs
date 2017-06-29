using DependencyChecker.Dependencies;
using DependencyChecker.Dependencies.SupportedFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace DependencyFileCreator.Dependencies {
    static class DependencyFileController {

        public static List<DependencyMetaData> LoadFromFile(string rootDir) {
            return DependenciesFile.TryParseFile(rootDir).Dependencies;
        }

        public static void SaveToFile(string filePath, List<DependencyMetaData> dependencies) {
            XDocument doc = new XDocument();
            XElement rootElement = new XElement("Dependencies");

            foreach (var dependency in dependencies) {
                XElement dependencyElement = new XElement("Dependency", 
                    new XElement("Identifier", dependency.Identifier),
                    new XElement("SteamID", dependency.SteamID),
                    new XElement("RequiredVersion", dependency.RequiredVersion)
                    );
                rootElement.Add(dependencyElement);
            }

            doc.Add(rootElement);
            doc.Save(filePath);
        }
    }
}
