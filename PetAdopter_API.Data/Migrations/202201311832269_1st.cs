namespace PetAdopter_API.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1st : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adopter",
                c => new
                    {
                        AdopterId = c.Int(nullable: false, identity: true),
                        AdminId = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.AdopterId);
            
            CreateTable(
                "dbo.Domestic",
                c => new
                    {
                        DomesticId = c.Int(nullable: false, identity: true),
                        AdminId = c.Guid(nullable: false),
                        Species = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Breed = c.String(),
                        Sex = c.String(nullable: false),
                        IsSterile = c.Boolean(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        IsAdoptionPending = c.Boolean(nullable: false),
                        IsKidFriendly = c.Boolean(nullable: false),
                        IsPetFriendly = c.Boolean(nullable: false),
                        IsHypoallergenic = c.Boolean(nullable: false),
                        IsHouseTrained = c.Boolean(nullable: false),
                        IsDeclawed = c.Boolean(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        AdopterID = c.Int(nullable: false),
                        Shelter_Id = c.Int(),
                    })
                .PrimaryKey(t => t.DomesticId)
                .ForeignKey("dbo.Adopter", t => t.AdopterID, cascadeDelete: true)
                .ForeignKey("dbo.Shelter", t => t.Shelter_Id)
                .Index(t => t.AdopterID)
                .Index(t => t.Shelter_Id);
            
            CreateTable(
                "dbo.Exotic",
                c => new
                    {
                        ExoticId = c.Int(nullable: false, identity: true),
                        AdminId = c.Guid(nullable: false),
                        Species = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Breed = c.String(),
                        Sex = c.String(nullable: false),
                        IsSterile = c.Boolean(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        IsAdoptionPending = c.Boolean(nullable: false),
                        IsKidFriendly = c.Boolean(nullable: false),
                        IsPetFriendly = c.Boolean(nullable: false),
                        IsHypoallergenic = c.Boolean(nullable: false),
                        IsLegalInCity = c.Boolean(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        AdopterID = c.Int(nullable: false),
                        Shelter_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ExoticId)
                .ForeignKey("dbo.Adopter", t => t.AdopterID, cascadeDelete: true)
                .ForeignKey("dbo.Shelter", t => t.Shelter_Id)
                .Index(t => t.AdopterID)
                .Index(t => t.Shelter_Id);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Shelter",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdminId = c.Guid(nullable: false),
                        ShelterId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Rating = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.Exotic", "Shelter_Id", "dbo.Shelter");
            DropForeignKey("dbo.Domestic", "Shelter_Id", "dbo.Shelter");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Exotic", "AdopterID", "dbo.Adopter");
            DropForeignKey("dbo.Domestic", "AdopterID", "dbo.Adopter");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Exotic", new[] { "Shelter_Id" });
            DropIndex("dbo.Exotic", new[] { "AdopterID" });
            DropIndex("dbo.Domestic", new[] { "Shelter_Id" });
            DropIndex("dbo.Domestic", new[] { "AdopterID" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.Shelter");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Exotic");
            DropTable("dbo.Domestic");
            DropTable("dbo.Adopter");
        }
    }
}
