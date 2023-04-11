namespace TopMessenger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateUserProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Photo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Photo");
        }
    }
}
