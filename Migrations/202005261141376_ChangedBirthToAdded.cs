namespace ShelterAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedBirthToAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pets", "AddedDate", c => c.DateTime());
            DropColumn("dbo.Pets", "BirthDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pets", "BirthDate", c => c.DateTime());
            DropColumn("dbo.Pets", "AddedDate");
        }
    }
}
