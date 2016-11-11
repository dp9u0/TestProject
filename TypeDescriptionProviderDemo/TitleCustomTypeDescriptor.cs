#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

#endregion

namespace TypeDescriptionProviderDemo {

    internal class TitleCustomTypeDescriptor : CustomTypeDescriptor {

        private readonly List<PropertyDescriptor> customFields = new List<PropertyDescriptor>();

        public TitleCustomTypeDescriptor(ICustomTypeDescriptor parent, object instance)
            : base(parent) {
            Title title = (Title) instance;

            customFields.AddRange(CustomFieldsGenerator.GenerateCustomFields(title.Category)
                                                       .Select(f => new CustomFieldPropertyDescriptor(f))
                                                       .Cast<PropertyDescriptor>());

        }

        public override PropertyDescriptorCollection GetProperties() {
            return new PropertyDescriptorCollection(base.GetProperties()
                                                        .Cast<PropertyDescriptor>()
                                                        .Union(customFields)
                                                        .ToArray());
        }

        public override PropertyDescriptorCollection GetProperties(Attribute[] attributes) {
            return new PropertyDescriptorCollection(base.GetProperties(attributes)
                                                        .Cast<PropertyDescriptor>()
                                                        .Union(customFields)
                                                        .ToArray());
        }

    }

}