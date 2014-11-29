namespace Library.DataAccessLayer.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class V4 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PersonHistories", newName: "PersonOperations");
            AddColumn("dbo.PersonOperations", "OperationType", c => c.Int(nullable: false));
            DropColumn("dbo.PersonOperations", "Operation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PersonOperations", "Operation", c => c.Int(nullable: false));
            DropColumn("dbo.PersonOperations", "OperationType");
            RenameTable(name: "dbo.PersonOperations", newName: "PersonHistories");
        }
    }
}
