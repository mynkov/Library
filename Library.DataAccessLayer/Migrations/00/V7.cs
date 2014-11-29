namespace Library.DataAccessLayer.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class V7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PersonOperations", "User_Id", "dbo.Users");
            DropIndex("dbo.PersonOperations", new[] { "User_Id" });
            AlterColumn("dbo.PersonOperations", "User_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.PersonOperations", "User_Id");
            AddForeignKey("dbo.PersonOperations", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonOperations", "User_Id", "dbo.Users");
            DropIndex("dbo.PersonOperations", new[] { "User_Id" });
            AlterColumn("dbo.PersonOperations", "User_Id", c => c.Int());
            CreateIndex("dbo.PersonOperations", "User_Id");
            AddForeignKey("dbo.PersonOperations", "User_Id", "dbo.Users", "Id");
        }
    }
}
