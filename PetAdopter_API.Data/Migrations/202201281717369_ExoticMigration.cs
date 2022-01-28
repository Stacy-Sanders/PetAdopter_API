namespace PetAdopter_API.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExoticMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Exotic", "ShelterId", "dbo.Shelter");
            DropIndex("dbo.Exotic", new[] { "ShelterId" });
            DropPrimaryKey("dbo.Exotic");
            AddColumn("dbo.Exotic", "ExoticId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Exotic", "AdminId", c => c.Guid(nullable: false));
            AddColumn("dbo.Exotic", "IsSterile", c => c.Boolean(nullable: false));
            AddColumn("dbo.Exotic", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
            AddPrimaryKey("dbo.Exotic", "ExoticId");
            DropColumn("dbo.Exotic", "Id");
            DropColumn("dbo.Exotic", "Sterile");
            DropColumn("dbo.Exotic", "ShelterId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Exotic", "ShelterId", c => c.Int(nullable: false));
            AddColumn("dbo.Exotic", "Sterile", c => c.Boolean(nullable: false));
            AddColumn("dbo.Exotic", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Exotic");
            DropColumn("dbo.Exotic", "ModifiedUtc");
            DropColumn("dbo.Exotic", "IsSterile");
            DropColumn("dbo.Exotic", "AdminId");
            DropColumn("dbo.Exotic", "ExoticId");
            AddPrimaryKey("dbo.Exotic", "Id");
            CreateIndex("dbo.Exotic", "ShelterId");
            AddForeignKey("dbo.Exotic", "ShelterId", "dbo.Shelter", "Id", cascadeDelete: true);
        }
    }
}
