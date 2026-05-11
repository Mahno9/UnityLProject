using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

using UnityEditor;

namespace _Project.Develop.Editor
{
    [InitializeOnLoad]
    public static class ScenesReferenceGenerator
    {
        private const string OutputPath = "Assets/Scripts/Generated/S.cs";

        static ScenesReferenceGenerator()
        {
            Generate();
        }

        [MenuItem("Tools/Regenerate S.cs")]
        public static void Generate()
        {
            List<SceneEntry> scenes = CollectScenes();
            string           code   = BuildCode(scenes);
            WriteIfChanged(code);
        }

        private static List<SceneEntry> CollectScenes()
        {
            List<SceneEntry> entries = new();
            string[]         guids   = AssetDatabase.FindAssets("t:Scene", new[] { "Assets" });

            foreach (string guid in guids)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(guid);
                if (string.IsNullOrEmpty(assetPath)) continue;
                if (!assetPath.EndsWith(".unity")) continue;

                string name = Path.GetFileNameWithoutExtension(assetPath);

                string folder = Path.GetDirectoryName(assetPath)?.Replace('\\', '/');
                if (folder != null && folder.StartsWith("Assets/"))
                    folder = folder.Substring("Assets/".Length);
                else if (folder == "Assets")
                    folder = string.Empty;

                entries.Add(new SceneEntry(folder ?? string.Empty, name));
            }

            entries.Sort((a, b) => string.CompareOrdinal(
                $"{a.Folder}/{a.Name}", $"{b.Folder}/{b.Name}"));

            return entries;
        }

        private static string BuildCode(List<SceneEntry> scenes)
        {
            Node root = new("S");

            foreach (SceneEntry entry in scenes)
            {
                Node current = root;

                if (!string.IsNullOrEmpty(entry.Folder))
                    foreach (string part in entry.Folder.Split('/'))
                    {
                        string folderName = Sanitize(part);
                        if (!current.Children.TryGetValue(folderName, out Node child))
                        {
                            child = new Node(folderName);
                            current.Children[folderName] = child;
                        }

                        current = child;
                    }

                string constName = Sanitize(entry.Name);
                current.Constants[constName] = entry.Name;
            }

            StringBuilder sb = new();
            sb.AppendLine("// AUTO-GENERATED — DO NOT EDIT");
            sb.AppendLine("// Re-generated on each compilation via ScenesReferenceGenerator.cs");
            sb.AppendLine();
            sb.AppendLine("public static class S");
            sb.AppendLine("{");
            WriteNode(root, sb, 1);
            sb.AppendLine("}");

            return sb.ToString();
        }

        private static void WriteNode(Node node, StringBuilder sb, int indent)
        {
            string pad = new(' ', indent * 4);

            foreach (KeyValuePair<string, string> constant in node.Constants)
                sb.AppendLine($"{pad}public const string {constant.Key} = \"{constant.Value}\";");

            foreach (KeyValuePair<string, Node> child in node.Children)
            {
                sb.AppendLine($"{pad}public static class {child.Key}");
                sb.AppendLine($"{pad}{{");
                WriteNode(child.Value, sb, indent + 1);
                sb.AppendLine($"{pad}}}");
            }
        }

        private static void WriteIfChanged(string code)
        {
            string directory = Path.GetDirectoryName(OutputPath);
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            if (File.Exists(OutputPath) && File.ReadAllText(OutputPath) == code)
                return;

            File.WriteAllText(OutputPath, code);
            AssetDatabase.ImportAsset(OutputPath, ImportAssetOptions.ForceUpdate);
        }

        private static string Sanitize(string name)
        {
            string result = Regex.Replace(name, @"[^a-zA-Z0-9_]", "_");
            if (result.Length > 0 && char.IsDigit(result[0]))
                result = "_" + result;
            return result;
        }

        private readonly struct SceneEntry
        {
            public readonly string Folder;
            public readonly string Name;

            public SceneEntry(string folder, string name)
            {
                Folder = folder;
                Name = name;
            }
        }

        private class Node
        {
            public readonly Dictionary<string, Node>   Children  = new();
            public readonly Dictionary<string, string> Constants = new();

            public Node(string name)
            {
            }
        }
    }
}