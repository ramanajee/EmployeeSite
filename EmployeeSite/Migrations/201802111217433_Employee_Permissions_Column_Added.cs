namespace EmployeeSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Employee_Permissions_Column_Added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Permissions", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Permissions");
        }
    }
}
