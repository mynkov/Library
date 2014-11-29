namespace Library.DataAccessLayer.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class V2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PersonHistories", "Object", c => c.String(storeType: "xml"));
            AlterColumn("dbo.PersonHistories", "Operation", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PersonHistories", "Operation", c => c.String());
            DropColumn("dbo.PersonHistories", "Object");
        }
    }
}
