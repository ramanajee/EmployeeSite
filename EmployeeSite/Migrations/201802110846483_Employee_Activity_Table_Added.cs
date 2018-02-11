namespace EmployeeSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Employee_Activity_Table_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeActivities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        ChangeType = c.String(),
                        NewValue = c.String(),
                        OldValue = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmployeeActivities");
        }
    }
}
