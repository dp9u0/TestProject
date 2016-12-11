namespace CodeFirstExistingDatabaseSample {
    public class Model1 : DbContext {
        public Model1()
            : base("Model1") {
        }

        public virtual DbSet<Blogs> Blogs { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
        }
    }
}