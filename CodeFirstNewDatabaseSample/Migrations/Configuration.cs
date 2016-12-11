namespace CodeFirstNewDatabaseSample.Migrations {
    internal sealed class Configuration : DbMigrationsConfiguration<BloggingContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CodeFirstNewDatabaseSample.BloggingContext";
        }

        protected override void Seed(BloggingContext context) {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}