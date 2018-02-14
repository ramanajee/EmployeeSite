namespace EmployeeSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Permission_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .Index(t => t.Employee_Id);
            
            DropColumn("dbo.Employees", "Permissions");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Permissions", c => c.String());
            DropForeignKey("dbo.Permissions", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.Permissions", new[] { "Employee_Id" });
            DropTable("dbo.Permissions");
        }
    }
}
