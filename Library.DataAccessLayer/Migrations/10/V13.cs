namespace Library.DataAccessLayer.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class V13 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BooksOperations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false),
                        OperationType = c.Int(nullable: false),
                        Object = c.String(storeType: "xml"),
                        EntityId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.EntityId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.EntityId, name: "IX_Entity_Id")
                .Index(t => t.UserId, name: "IX_User_Id");
            
            CreateTable(
                "dbo.PeopleOperations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false),
                        OperationType = c.Int(nullable: false),
                        Object = c.String(storeType: "xml"),
                        EntityId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.EntityId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
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
                        EntityId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.EntityId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.EntityId, name: "IX_Entity_Id")
                .Index(t => t.UserId, name: "IX_User_Id");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersOperations", "UserId", "dbo.Users");
            DropForeignKey("dbo.UsersOperations", "EntityId", "dbo.Users");
            DropForeignKey("dbo.PeopleOperations", "UserId", "dbo.Users");
            DropForeignKey("dbo.PeopleOperations", "EntityId", "dbo.People");
            DropForeignKey("dbo.BooksOperations", "UserId", "dbo.Users");
            DropForeignKey("dbo.BooksOperations", "EntityId", "dbo.Books");
            DropIndex("dbo.UsersOperations", "IX_User_Id");
            DropIndex("dbo.UsersOperations", "IX_Entity_Id");
            DropIndex("dbo.PeopleOperations", "IX_User_Id");
            DropIndex("dbo.PeopleOperations", "IX_Entity_Id");
            DropIndex("dbo.BooksOperations", "IX_User_Id");
            DropIndex("dbo.BooksOperations", "IX_Entity_Id");
            DropTable("dbo.UsersOperations");
            DropTable("dbo.PeopleOperations");
            DropTable("dbo.BooksOperations");
        }
    }
}
