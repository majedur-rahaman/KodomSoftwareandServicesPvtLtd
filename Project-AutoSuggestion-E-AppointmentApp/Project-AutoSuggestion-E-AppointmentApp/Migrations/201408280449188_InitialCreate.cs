namespace Project_AutoSuggestion_E_AppointmentApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        GenderId = c.Int(nullable: false, identity: true),
                        GenderType = c.String(),
                    })
                .PrimaryKey(t => t.GenderId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientId = c.Int(nullable: false, identity: true),
                        PatientName = c.String(nullable: false, maxLength: 50),
                        PatientAge = c.String(nullable: false),
                        PatientEmail = c.String(nullable: false),
                        PatientPhoneNumber = c.String(nullable: false),
                        PatientAddress = c.String(),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        GenderId = c.Int(nullable: false),
                        PatientImage = c.String(),
                    })
                .PrimaryKey(t => t.PatientId)
                .ForeignKey("dbo.Genders", t => t.GenderId, cascadeDelete: true)
                .Index(t => t.GenderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "GenderId", "dbo.Genders");
            DropIndex("dbo.Patients", new[] { "GenderId" });
            DropTable("dbo.Patients");
            DropTable("dbo.Genders");
        }
    }
}
