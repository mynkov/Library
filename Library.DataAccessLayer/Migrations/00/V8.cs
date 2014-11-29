namespace Library.DataAccessLayer.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class V8 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.PersonBooks", name: "Person_Id", newName: "PersonId");
            RenameColumn(table: "dbo.PersonBooks", name: "Book_Id", newName: "BookId");
            RenameColumn(table: "dbo.PersonOperations", name: "Entity_Id", newName: "EntityId");
            RenameColumn(table: "dbo.PersonOperations", name: "User_Id", newName: "UserId");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.PersonOperations", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.PersonOperations", name: "EntityId", newName: "Entity_Id");
            RenameColumn(table: "dbo.PersonBooks", name: "BookId", newName: "Book_Id");
            RenameColumn(table: "dbo.PersonBooks", name: "PersonId", newName: "Person_Id");
        }
    }
}
