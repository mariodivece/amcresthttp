using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;

namespace Amcrest.HttpApi.Sample
{
    public sealed class Node
    {
        private readonly Dictionary<string, Node> m_Children = new Dictionary<string, Node>();

        public Node(string name, Node parent)
        {
            Name = name;
            Parent = parent;
            Text = null;
        }

        public string Name { get; private set; }

        public Node Parent { get; private set; }

        public bool IsArrayItemNode { get { return Name.All(c => char.IsDigit(c)); } }

        public bool IsArrayNode { get { return Children.Count > 0 && Children.All(c => c.IsArrayItemNode); } }

        public ReadOnlyCollection<Node> Children { get { return new ReadOnlyCollection<Node>(m_Children.Values.ToArray()); } }

        public string Text { get; private set; }

        public Node this[string childName]
        {
            get
            {
                if (m_Children.ContainsKey(childName) == false)
                    m_Children[childName] = new Node(childName, this);

                return m_Children[childName];
            }
        }

        public static Node FromFormData(string formData)
        {
            var result = new Node("root", null);

            var payloadLines = formData.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in payloadLines)
            {
                var separatorIndex = line.LastIndexOf('=');
                var textValue = line.Substring(separatorIndex + 1);
                var paths = line.Substring(0, separatorIndex).Split('.');
                var currentNode = result;

                for (var pathIndex = 0; pathIndex < paths.Length; pathIndex++)
                {
                    var currentPath = paths[pathIndex];

                    if (currentPath.EndsWith(']'))
                    {
                        var arrayName = currentPath.Substring(0, currentPath.LastIndexOf('['));
                        var arrayIndex = currentPath.Substring(currentPath.LastIndexOf('[') + 1).TrimEnd(']');

                        currentNode = currentNode[arrayName][arrayIndex];
                    }
                    else
                    {
                        currentNode = currentNode[currentPath];
                    }
                }

                currentNode.Text = textValue;

            }

            if (result.Children.Count == 1)
            {
                result = result.Children[0];
                result.Parent = null;
            }

            return result;
        }

        public static T FromFormData<T>(string formData)
        {
            var node = FromFormData(formData);
            return node.Deserialize<T>();
        }

        public static T FromFormData<T>(string formData, JsonSerializerSettings settings)
        {
            var node = FromFormData(formData);
            return node.Deserialize<T>(settings);
        }

        public static T FromFormData<T>(string formData, params JsonConverter[] converters)
        {
            var node = FromFormData(formData);
            return node.Deserialize<T>(converters);
        }

        public T Deserialize<T>()
        {
            return JsonConvert.DeserializeObject<T>(ToString());

        }

        public T Deserialize<T>(JsonSerializerSettings settings)
        {
            return JsonConvert.DeserializeObject<T>(ToString(), settings);
        }

        public T Deserialize<T>(params JsonConverter[] converters)
        {
            return JsonConvert.DeserializeObject<T>(ToString(), converters);
        }

        public string ToJson()
        {
            var json = BuildJsonString();
            return JsonConvert.DeserializeObject(BuildJsonString()).ToString();
        }

        public override string ToString()
        {
            return ToJson();
        }

        private string BuildJsonString()
        {
            var builder = new StringBuilder();
            if (Parent == null) builder.Append("{ ");

            if (IsArrayNode)
            {
                builder.Append($"\"{Name}\": [ ");
                foreach (var c in Children)
                {
                    builder.Append(c.BuildJsonString());
                }

                builder.Append(" ] ");
                if (Parent != null && this != Parent.Children.Last())
                    builder.Append(",");
            }
            else if (Text != null)
            {
                var textValue = $" \"{Text}\"";
                if (Text.Equals("true") || Text.Equals("false"))
                    textValue = $" {Text}";
                else if (Text.All(c => char.IsDigit(c)))
                    textValue = $" {Text}";

                if (IsArrayItemNode)
                    builder.Append(textValue);
                else
                    builder.Append($"\"{Name}\": {textValue}");

                if (Parent != null && this != Parent.Children.Last())
                    builder.Append(",");
            }
            else
            {
                if (IsArrayItemNode)
                    builder.Append(" { ");
                else
                    builder.Append($"\"{Name}\": {{ ");

                if (Text != null)
                {
                    builder.Append($" \"Text\": \"{Text}\"");
                }
                else
                {
                    foreach (var c in Children)
                    {
                        builder.Append(c.BuildJsonString());
                    }
                }

                builder.Append(" } ");
                if (Parent != null && this != Parent.Children.Last())
                    builder.Append(",");
            }

            if (Parent == null) builder.Append(" }");
            return builder.ToString();
        }

    }
}
