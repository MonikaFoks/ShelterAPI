namespace ShelterAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRequiredDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pets", "AddedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pets", "AddedDate", c => c.DateTime());
        }
    }
}
