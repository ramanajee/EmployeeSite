namespace EmployeeSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Permission_Tie_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PermissionTies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        PermissionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.PermissionId, cascadeDelete: true)
                .ForeignKey("dbo.Permissions", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.PermissionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PermissionTies", "EmployeeId", "dbo.Permissions");
            DropForeignKey("dbo.PermissionTies", "PermissionId", "dbo.Employees");
            DropIndex("dbo.PermissionTies", new[] { "PermissionId" });
            DropIndex("dbo.PermissionTies", new[] { "EmployeeId" });
            DropTable("dbo.PermissionTies");
        }
    }
}
