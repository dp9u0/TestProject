#region

using System.Collections.Generic;

#endregion

namespace T4Demo3 {
    internal class Program {
        private static void Main(string[] args) {
            var data = new List<string>();
            data.Add("1");
            data.Add("2");

            data.Add("3");

            var template = new RuntimeTextTemplate(data);
            System.IO.File.WriteAllText("text.html", template.TransformText());
        }
    }
}