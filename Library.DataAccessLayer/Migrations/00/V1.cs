namespace Library.DataAccessLayer.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class V1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Age = c.Int(nullable: false),
                        RegistrationDate = c.DateTime(),
                        Gender = c.Int(nullable: false),
                        Education = c.Int(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        Annotation = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        Operation = c.String(),
                        Entity_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Entity_Id)
                .Index(t => t.Entity_Id);
            
            CreateTable(
                "dbo.PersonBooks",
                c => new
                    {
                        Person_Id = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Person_Id, t.Book_Id })
                .ForeignKey("dbo.People", t => t.Person_Id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .Index(t => t.Person_Id)
                .Index(t => t.Book_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonHistories", "Entity_Id", "dbo.People");
            DropForeignKey("dbo.PersonBooks", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.PersonBooks", "Person_Id", "dbo.People");
            DropIndex("dbo.PersonBooks", new[] { "Book_Id" });
            DropIndex("dbo.PersonBooks", new[] { "Person_Id" });
            DropIndex("dbo.PersonHistories", new[] { "Entity_Id" });
            DropTable("dbo.PersonBooks");
            DropTable("dbo.PersonHistories");
            DropTable("dbo.People");
            DropTable("dbo.Books");
        }
    }
}
