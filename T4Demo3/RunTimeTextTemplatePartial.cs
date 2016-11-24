using System;
using System.Collections.Generic;


namespace T4Demo3 {
    public partial class RuntimeTextTemplate {

        private List<string> items;

        public List<string> Items {
            get {
                return items;
            }
            set {
                items = value;
            }
        }

        public RuntimeTextTemplate(List<string> data) {
            this.items = data;
        }
    }
}
