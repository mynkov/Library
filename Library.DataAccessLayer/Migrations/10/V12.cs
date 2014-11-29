namespace Library.DataAccessLayer.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class V12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BooksOperations", "EntityId", "dbo.Books");
            DropForeignKey("dbo.BooksOperations", "UserId", "dbo.Users");
            DropForeignKey("dbo.PeopleOperations", "EntityId", "dbo.People");
            DropForeignKey("dbo.PeopleOperations", "UserId", "dbo.Users");
            DropForeignKey("dbo.UsersOperations", "EntityId", "dbo.Users");
            DropForeignKey("dbo.UsersOperations", "UserId", "dbo.Users");
            DropIndex("dbo.BooksOperations", "IX_Entity_Id");
            DropIndex("dbo.BooksOperations", "IX_User_Id");
            DropIndex("dbo.PeopleOperations", "IX_Entity_Id");
            DropIndex("dbo.PeopleOperations", "IX_User_Id");
            DropIndex("dbo.UsersOperations", "IX_Entity_Id");
            DropIndex("dbo.UsersOperations", "IX_User_Id");
            DropTable("dbo.BooksOperations");
            DropTable("dbo.PeopleOperations");
            DropTable("dbo.UsersOperations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UsersOperations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false),
                        OperationType = c.Int(nullable: false),
                        Object = c.String(storeType: "xml"),
                        EntityId = c.Int(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BooksOperations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false),
                        OperationType = c.Int(nullable: false),
                        Object = c.String(storeType: "xml"),
                        EntityId = c.Int(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.UsersOperations", "UserId", name: "IX_User_Id");
            CreateIndex("dbo.UsersOperations", "EntityId", name: "IX_Entity_Id");
            CreateIndex("dbo.PeopleOperations", "UserId", name: "IX_User_Id");
            CreateIndex("dbo.PeopleOperations", "EntityId", name: "IX_Entity_Id");
            CreateIndex("dbo.BooksOperations", "UserId", name: "IX_User_Id");
            CreateIndex("dbo.BooksOperations", "EntityId", name: "IX_Entity_Id");
            AddForeignKey("dbo.UsersOperations", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UsersOperations", "EntityId", "dbo.Users", "Id");
            AddForeignKey("dbo.PeopleOperations", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PeopleOperations", "EntityId", "dbo.People", "Id");
            AddForeignKey("dbo.BooksOperations", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BooksOperations", "EntityId", "dbo.Books", "Id");
        }
    }
}
