#region

using System;
using System.Collections.Generic;

#endregion

namespace TypeDescriptionProviderDemo {

    internal static class CustomFieldsGenerator {

        internal static IEnumerable<CustomField> GenerateCustomFields(TitleCategory category) {
            List<CustomField> customFields = new List<CustomField>();

            switch (category) {
                case TitleCategory.Book:
                    customFields.Add(new CustomField("Author", typeof (String)));
                    customFields.Add(new CustomField("HardCover", typeof (bool)));
                    customFields.Add(new CustomField("Amazon Rank", typeof (int)));
                    break;

                case TitleCategory.Movie:
                    customFields.Add(new CustomField("Director", typeof (String)));
                    customFields.Add(new CustomField("Rating", typeof (MovieRating)));
                    customFields.Add(new CustomField("Duration", typeof (TimeSpan)));
                    customFields.Add(new CustomField("Release Date", typeof (DateTime)));
                    break;
            }

            return customFields;
        }

    }

}