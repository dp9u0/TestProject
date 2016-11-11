#region

using System;
using System.Collections.Generic;
using System.ComponentModel;

#endregion

namespace TypeDescriptionProviderDemo {

    [TypeDescriptionProvider(typeof (TitleTypeDescriptionProvider))]
    internal sealed class Title {

        private Dictionary<String, Object> customFieldValues = new Dictionary<String, Object>();

        public Title(String name, TitleCategory category) {
            Name = name;
            Category = category;
        }

        public String Name {
            get;
            set;
        }

        [Browsable(false)]
        public TitleCategory Category {
            get;
            private set;
        }

        public Object this[String fieldName] {
            get {
                Object value = null;
                customFieldValues.TryGetValue(fieldName, out value);
                return value;
            }

            set {
                customFieldValues[fieldName] = value;
            }
        }

        public override string ToString() {
            return Name;
        }

    }

}