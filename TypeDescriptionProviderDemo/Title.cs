#region

using System.Collections.Generic;
using System.ComponentModel;

#endregion

namespace TypeDescriptionProviderDemo {
    [TypeDescriptionProvider(typeof(TitleTypeDescriptionProvider))]
    internal sealed class Title {
        private Dictionary<string, object> customFieldValues = new Dictionary<string, object>();

        public Title(string name, TitleCategory category) {
            Name = name;
            Category = category;
        }

        public string Name { get; set; }

        [Browsable(false)]
        public TitleCategory Category { get; private set; }

        public object this[string fieldName] {
            get {
                object value = null;
                customFieldValues.TryGetValue(fieldName, out value);
                return value;
            }

            set { customFieldValues[fieldName] = value; }
        }

        public override string ToString() {
            return Name;
        }
    }
}