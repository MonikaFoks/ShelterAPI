namespace ShelterAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(),
                        Phone = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                        ShelterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Shelters", t => t.ShelterId, cascadeDelete: true)
                .Index(t => t.ShelterId);
            
            CreateTable(
                "dbo.Shelters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.String(),
                        Street = c.String(),
                        Number = c.Int(nullable: false),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PetName = c.String(nullable: false),
                        Species = c.String(),
                        Breed = c.String(),
                        Description = c.String(),
                        ShelterId = c.Int(nullable: false),
                        BirthDate = c.DateTime(),
                        IsAdopted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Shelters", t => t.ShelterId, cascadeDelete: true)
                .Index(t => t.ShelterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pets", "ShelterId", "dbo.Shelters");
            DropForeignKey("dbo.Employees", "ShelterId", "dbo.Shelters");
            DropIndex("dbo.Pets", new[] { "ShelterId" });
            DropIndex("dbo.Employees", new[] { "ShelterId" });
            DropTable("dbo.Pets");
            DropTable("dbo.Shelters");
            DropTable("dbo.Employees");
        }
    }
}
