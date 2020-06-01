namespace ShelterAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeesChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "LoginErrorMessage", c => c.String());
            AlterColumn("dbo.Employees", "FirstName", c => c.String());
            AlterColumn("dbo.Employees", "LastName", c => c.String());
            AlterColumn("dbo.Employees", "Login", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Password", c => c.String());
            AlterColumn("dbo.Employees", "Login", c => c.String());
            AlterColumn("dbo.Employees", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "FirstName", c => c.String(nullable: false));
            DropColumn("dbo.Employees", "LoginErrorMessage");
        }
    }
}
