#region

using System.Collections.Generic;

#endregion

namespace T4Demo3 {
    public partial class RuntimeTextTemplate {
        private List<string> items;

        public RuntimeTextTemplate(List<string> data) {
            items = data;
        }

        public List<string> Items {
            get { return items; }
            set { items = value; }
        }
    }
}