namespace Library.DataAccessLayer.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class V3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.People", "PhoneNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "PhoneNumber", c => c.String());
        }
    }
}
