#region

using System;

#endregion

namespace CnblogsLinqProvider {
    public class SearchCriteria {
        public string Title { get; set; }
        public string Author { get; set; }

        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }

        public int MinDiggs { get; set; }
        public int MaxDiggs { get; set; }
        public int MinViews { get; set; }
        public int MaxViews { get; set; }
        public int MinComments { get; set; }
        public int MaxComments { get; set; }
    }
}