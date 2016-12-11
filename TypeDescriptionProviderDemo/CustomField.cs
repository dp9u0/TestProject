#region

using System;

#endregion

namespace TypeDescriptionProviderDemo {
    internal class CustomField {
        public CustomField(string name, Type dataType) {
            Name = name;
            DataType = dataType;
        }

        public string Name { get; private set; }

        public Type DataType { get; private set; }
    }
}