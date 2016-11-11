namespace CodeFirstNewDatabaseSample.Migrations {
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddUser : DbMigration {
        public override void Up() {
            CreateTable(
                "dbo.User",
                c => new {
                    Username = c.String(),
                    DisplayName = c.String(),
                });
        }

        public override void Down() {
            DropTable("dbo.Users");
        }
    }
}
