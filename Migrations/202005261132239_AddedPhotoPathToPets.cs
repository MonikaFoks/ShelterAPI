namespace ShelterAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPhotoPathToPets : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pets", "PhotoPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pets", "PhotoPath");
        }
    }
}
