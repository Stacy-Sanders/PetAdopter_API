namespace PetAdopter_API.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1st : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DomesticTable", "ShelterId", "dbo.Shelter");
            DropForeignKey("dbo.ExoticTable", "ShelterId", "dbo.Shelter");
            DropIndex("dbo.DomesticTable", new[] { "ShelterId" });
            DropIndex("dbo.ExoticTable", new[] { "ShelterId" });
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
                        AdopterID = c.Int(nullable: false),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        Shelter_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ExoticId)
                .ForeignKey("dbo.Adopter", t => t.AdopterID, cascadeDelete: true)
                .ForeignKey("dbo.Shelter", t => t.Shelter_Id)
                .Index(t => t.AdopterID)
                .Index(t => t.Shelter_Id);
            
            DropTable("dbo.AdopterTable");
            DropTable("dbo.DomesticTable");
            DropTable("dbo.ExoticTable");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ExoticTable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Breed = c.String(nullable: false),
                        Species = c.String(nullable: false),
                        Sex = c.String(nullable: false),
                        Sterile = c.Boolean(nullable: false),
                        Birthdate = c.DateTime(nullable: false),
                        IsAdoptionPending = c.Boolean(nullable: false),
                        IsKidFriendly = c.Boolean(nullable: false),
                        IsPetFriendly = c.Boolean(nullable: false),
                        IsHypoallergenic = c.Boolean(nullable: false),
                        IsLegalInCity = c.Boolean(nullable: false),
                        ShelterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DomesticTable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
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
                        ShelterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AdopterTable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Exotic", "Shelter_Id", "dbo.Shelter");
            DropForeignKey("dbo.Domestic", "Shelter_Id", "dbo.Shelter");
            DropForeignKey("dbo.Exotic", "AdopterID", "dbo.Adopter");
            DropForeignKey("dbo.Domestic", "AdopterID", "dbo.Adopter");
            DropIndex("dbo.Exotic", new[] { "Shelter_Id" });
            DropIndex("dbo.Exotic", new[] { "AdopterID" });
            DropIndex("dbo.Domestic", new[] { "Shelter_Id" });
            DropIndex("dbo.Domestic", new[] { "AdopterID" });
            DropTable("dbo.Exotic");
            DropTable("dbo.Domestic");
            DropTable("dbo.Adopter");
            CreateIndex("dbo.ExoticTable", "ShelterId");
            CreateIndex("dbo.DomesticTable", "ShelterId");
            AddForeignKey("dbo.ExoticTable", "ShelterId", "dbo.Shelter", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DomesticTable", "ShelterId", "dbo.Shelter", "Id", cascadeDelete: true);
        }
    }
}
