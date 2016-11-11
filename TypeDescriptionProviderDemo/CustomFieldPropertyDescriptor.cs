#region

using System;
using System.ComponentModel;

#endregion

namespace TypeDescriptionProviderDemo {

    internal class CustomFieldPropertyDescriptor : PropertyDescriptor {

        public CustomFieldPropertyDescriptor(CustomField customField)
            : base(customField.Name, new Attribute[0]) {
            CustomField = customField;
        }

        public CustomField CustomField {
            get;
            private set;
        }

        public override Type ComponentType {
            get {
                return typeof (Title);
            }
        }

        public override bool IsReadOnly {
            get {
                return false;
            }
        }

        public override Type PropertyType {
            get {
                return CustomField.DataType;
            }
        }

        public override bool CanResetValue(object component) {
            return false;
        }

        public override object GetValue(object component) {
            Title title = (Title) component;
            return title[CustomField.Name]
                   ?? (CustomField.DataType.IsValueType ? (Object) Activator.CreateInstance(CustomField.DataType) : null);
        }

        public override void ResetValue(object component) {
            throw new NotImplementedException();
        }

        public override void SetValue(object component, object value) {
            Title title = (Title) component;
            title[CustomField.Name] = value;
        }

        public override bool ShouldSerializeValue(object component) {
            return false;
        }

    }

}