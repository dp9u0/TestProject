#region

using System;
using System.Collections.ObjectModel;
using System.Linq;

#endregion

namespace TypeDescriptionProviderDemo {
    internal static class DemoDataProvider {
        public static ReadOnlyCollection<Title> GetTitles() {
            return new[] {
                GetBook("C++/CLI in Action", "Nishant Sivakumar", false, 34),
                GetMovie("Spiderman III", "Sam Raimi", MovieRating.PG13, new TimeSpan(2, 19, 10),
                    new DateTime(2007, 5, 1)),
                null
            }.ToList().AsReadOnly();
        }

        private static Title GetBook(string name, string author, bool isHardCover, int amazonRank) {
            Title title = new Title(name, TitleCategory.Book);
            title["Author"] = author;
            title["HardCover"] = isHardCover;
            title["Amazon Rank"] = amazonRank;
            return title;
        }

        private static Title GetMovie(string name,
            string director,
            MovieRating rating,
            TimeSpan duration,
            DateTime releaseDate) {
            Title title = new Title(name, TitleCategory.Movie);
            title["Director"] = director;
            title["Rating"] = rating;
            title["Duration"] = duration;
            title["Release Date"] = releaseDate;
            return title;
        }
    }
}