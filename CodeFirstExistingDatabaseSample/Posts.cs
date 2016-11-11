namespace CodeFirstExistingDatabaseSample {
    using System.ComponentModel.DataAnnotations;

    public partial class Posts
    {
        [Key]
        public int PostId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int BlogId { get; set; }

        public virtual Blogs Blogs { get; set; }
    }
}
