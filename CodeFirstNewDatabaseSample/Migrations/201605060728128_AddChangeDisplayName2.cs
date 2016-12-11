namespace CodeFirstNewDatabaseSample.Migrations {
    public partial class AddChangeDisplayName2 : DbMigration {
        public override void Up() {
            RenameColumn("dbo.User", "DisplayName", "display_name");
        }

        public override void Down() {
            RenameColumn("dbo.User", "display_name", "DisplayName");
        }
    }
}