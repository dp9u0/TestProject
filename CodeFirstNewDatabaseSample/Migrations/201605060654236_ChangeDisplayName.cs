using System.Data.Entity.Migrations;

namespace CodeFirstNewDatabaseSample.Migrations {
    public partial class ChangeDisplayName : DbMigration {
        public override void Up() {
            RenameColumn("dbo.User", "DisplayName", "display_name");
        }

        public override void Down() {
            RenameColumn("dbo.User", "display_name", "DisplayName");
        }
    }
}