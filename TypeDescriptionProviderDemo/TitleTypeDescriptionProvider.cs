#region

using System;
using System.ComponentModel;

#endregion

namespace TypeDescriptionProviderDemo {
    internal class TitleTypeDescriptionProvider : TypeDescriptionProvider {
        private static TypeDescriptionProvider defaultTypeProvider = TypeDescriptor.GetProvider(typeof(Title));

        public TitleTypeDescriptionProvider() : base(defaultTypeProvider) {
        }

        public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance) {
            ICustomTypeDescriptor defaultDescriptor = base.GetTypeDescriptor(objectType, instance);

            return instance == null ? defaultDescriptor : new TitleCustomTypeDescriptor(defaultDescriptor, instance);
        }
    }
}