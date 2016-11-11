#region

using System;

#endregion

namespace TypeDescriptionProviderDemo {

    internal class CustomField {

        public CustomField(String name, Type dataType) {
            Name = name;
            DataType = dataType;
        }

        public String Name {
            get;
            private set;
        }

        public Type DataType {
            get;
            private set;
        }

    }

}