namespace Library.DataAccessLayer.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class V5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.PersonOperations", "User_Id", c => c.Int());
            CreateIndex("dbo.PersonOperations", "User_Id");
            AddForeignKey("dbo.PersonOperations", "User_Id", "dbo.Users", "Id");
            DropColumn("dbo.PersonOperations", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PersonOperations", "UserId", c => c.Guid(nullable: false));
            DropForeignKey("dbo.PersonOperations", "User_Id", "dbo.Users");
            DropIndex("dbo.PersonOperations", new[] { "User_Id" });
            DropColumn("dbo.PersonOperations", "User_Id");
            DropTable("dbo.Users");
        }
    }
}
