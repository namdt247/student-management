namespace StudentManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        AttendanceId = c.Int(nullable: false, identity: true),
                        SessionDetailId = c.Int(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                        Attend = c.Int(nullable: false),
                        Note = c.String(unicode: false, storeType: "text"),
                        Session_SessionId = c.Int(),
                    })
                .PrimaryKey(t => t.AttendanceId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.SessionDetails", t => t.SessionDetailId, cascadeDelete: true)
                .ForeignKey("dbo.Sessions", t => t.Session_SessionId)
                .Index(t => t.SessionDetailId)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.Session_SessionId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 255),
                        RollNumber = c.String(nullable: false, maxLength: 255),
                        Address = c.String(maxLength: 255),
                        Avatar = c.String(maxLength: 255),
                        Description = c.String(maxLength: 255),
                        Status = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.SessionDetails",
                c => new
                    {
                        SessionDetailId = c.Int(nullable: false, identity: true),
                        SessionId = c.Int(nullable: false),
                        SessionDetailName = c.String(),
                        TeacherId = c.String(),
                        RoomId = c.Int(nullable: false),
                        SessionDetailCode = c.String(nullable: false, maxLength: 255),
                        DateStart = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SessionDetailId)
                .ForeignKey("dbo.Sessions", t => t.SessionId, cascadeDelete: true)
                .Index(t => t.SessionId)
                .Index(t => t.SessionDetailCode, unique: true);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        SessionId = c.Int(nullable: false, identity: true),
                        RoomId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        CLazzId = c.Int(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                        NumBerSession = c.Int(nullable: false),
                        ListStudent = c.String(nullable: false, maxLength: 255),
                        StartTime = c.DateTime(nullable: false),
                        FinishTime = c.DateTime(nullable: false),
                        BeginTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SessionId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Clazzs", t => t.CLazzId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.RoomId)
                .Index(t => t.SubjectId)
                .Index(t => t.CLazzId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.Clazzs",
                c => new
                    {
                        ClazzId = c.Int(nullable: false, identity: true),
                        ClazzName = c.String(nullable: false, maxLength: 255),
                        ClazzCode = c.String(nullable: false, maxLength: 255),
                        ListStudentId = c.String(nullable: false, maxLength: 255),
                        Description = c.String(maxLength: 255),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClazzId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        RoomName = c.String(nullable: false, maxLength: 255),
                        RoomCode = c.String(nullable: false, maxLength: 255),
                        Description = c.String(maxLength: 255),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoomId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(nullable: false, maxLength: 255),
                        SubjectCode = c.String(nullable: false, maxLength: 255),
                        Description = c.String(maxLength: 255),
                        NumberLession = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.SessionDetails", "SessionId", "dbo.Sessions");
            DropForeignKey("dbo.Sessions", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Sessions", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Sessions", "CLazzId", "dbo.Clazzs");
            DropForeignKey("dbo.Attendances", "Session_SessionId", "dbo.Sessions");
            DropForeignKey("dbo.Sessions", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Attendances", "SessionDetailId", "dbo.SessionDetails");
            DropForeignKey("dbo.Attendances", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Sessions", new[] { "ApplicationUserId" });
            DropIndex("dbo.Sessions", new[] { "CLazzId" });
            DropIndex("dbo.Sessions", new[] { "SubjectId" });
            DropIndex("dbo.Sessions", new[] { "RoomId" });
            DropIndex("dbo.SessionDetails", new[] { "SessionDetailCode" });
            DropIndex("dbo.SessionDetails", new[] { "SessionId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Attendances", new[] { "Session_SessionId" });
            DropIndex("dbo.Attendances", new[] { "ApplicationUserId" });
            DropIndex("dbo.Attendances", new[] { "SessionDetailId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Subjects");
            DropTable("dbo.Rooms");
            DropTable("dbo.Clazzs");
            DropTable("dbo.Sessions");
            DropTable("dbo.SessionDetails");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Attendances");
        }
    }
}
