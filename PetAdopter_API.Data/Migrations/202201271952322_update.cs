namespace PetAdopter_API.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DomesticTable", "ShelterId", "dbo.Shelter");
            DropIndex("dbo.DomesticTable", new[] { "ShelterId" });
            DropColumn("dbo.DomesticTable", "ShelterId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DomesticTable", "ShelterId", c => c.Int(nullable: false));
            CreateIndex("dbo.DomesticTable", "ShelterId");
            AddForeignKey("dbo.DomesticTable", "ShelterId", "dbo.Shelter", "Id", cascadeDelete: true);
        }
    }
}
