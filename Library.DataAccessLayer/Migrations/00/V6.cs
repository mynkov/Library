namespace Library.DataAccessLayer.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class V6 : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.Users", "UserId", "dbo.aspnet_Users", "UserId");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserId", "dbo.aspnet_Users");
        }
    }
}
