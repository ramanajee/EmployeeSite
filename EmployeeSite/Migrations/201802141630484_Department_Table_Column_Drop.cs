namespace EmployeeSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Department_Table_Column_Drop : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Employees", "Department");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Department", c => c.String());
        }
    }
}
