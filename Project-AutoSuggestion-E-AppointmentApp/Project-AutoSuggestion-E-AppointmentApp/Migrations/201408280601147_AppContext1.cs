namespace Project_AutoSuggestion_E_AppointmentApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppContext1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        DesignationId = c.Int(nullable: false, identity: true),
                        DesignationType = c.String(),
                    })
                .PrimaryKey(t => t.DesignationId);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        DoctorId = c.Int(nullable: false, identity: true),
                        DoctorName = c.String(nullable: false, maxLength: 50),
                        DoctorEmail = c.String(nullable: false),
                        DoctorPhoneNumber = c.String(nullable: false),
                        DoctorLocation = c.String(),
                        DoctorDegree = c.String(nullable: false),
                        DesignationId = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        DoctorFee = c.Double(nullable: false),
                        DoctorExperience = c.Double(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        DoctorImage = c.String(),
                    })
                .PrimaryKey(t => t.DoctorId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Designations", t => t.DesignationId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.DesignationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.Doctors", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Doctors", new[] { "DesignationId" });
            DropIndex("dbo.Doctors", new[] { "DepartmentId" });
            DropTable("dbo.Doctors");
            DropTable("dbo.Designations");
        }
    }
}
