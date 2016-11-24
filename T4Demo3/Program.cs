using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4Demo3 {
    class Program {
        static void Main(string[] args) {
            var data = new List<string>();
            data.Add("1");
            data.Add("2");

            data.Add("3");

            var template = new RuntimeTextTemplate(data);
            System.IO.File.WriteAllText("text.html", template.TransformText());
        }
    }
}
