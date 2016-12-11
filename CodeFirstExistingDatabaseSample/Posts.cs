#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace CodeFirstExistingDatabaseSample {
    public class Posts {
        [Key]
        public int PostId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int BlogId { get; set; }

        public virtual Blogs Blogs { get; set; }
    }
}