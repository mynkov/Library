namespace Library.DataAccessLayer.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class V9 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PersonOperations", newName: "BooksOperations");
            DropForeignKey("dbo.PersonOperations", "UserId", "dbo.Users");
            DropIndex("dbo.BooksOperations", "IX_User_Id");
            CreateTable(
                "dbo.PeopleOperations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false),
                        OperationType = c.Int(nullable: false),
                        Object = c.String(storeType: "xml"),
                        EntityId = c.Int(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.EntityId, name: "IX_Entity_Id")
                .Index(t => t.UserId, name: "IX_User_Id");
            
            CreateTable(
                "dbo.UsersOperations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false),
                        OperationType = c.Int(nullable: false),
                        Object = c.String(storeType: "xml"),
                        EntityId = c.Int(),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.EntityId, name: "IX_Entity_Id")
                .Index(t => t.UserId, name: "IX_User_Id");
            
            AlterColumn("dbo.BooksOperations", "UserId", c => c.Int());
            CreateIndex("dbo.BooksOperations", "UserId", name: "IX_User_Id");
            AddForeignKey("dbo.BooksOperations", "UserId", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersOperations", "UserId", "dbo.Users");
            DropForeignKey("dbo.BooksOperations", "UserId", "dbo.Users");
            DropIndex("dbo.UsersOperations", "IX_User_Id");
            DropIndex("dbo.UsersOperations", "IX_Entity_Id");
            DropIndex("dbo.PeopleOperations", "IX_User_Id");
            DropIndex("dbo.PeopleOperations", "IX_Entity_Id");
            DropIndex("dbo.BooksOperations", "IX_User_Id");
            AlterColumn("dbo.BooksOperations", "UserId", c => c.Int(nullable: false));
            DropTable("dbo.UsersOperations");
            DropTable("dbo.PeopleOperations");
            CreateIndex("dbo.BooksOperations", "UserId", name: "IX_User_Id");
            AddForeignKey("dbo.PersonOperations", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.BooksOperations", newName: "PersonOperations");
        }
    }
}
