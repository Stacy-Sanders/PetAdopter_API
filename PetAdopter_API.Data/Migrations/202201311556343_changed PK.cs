namespace PetAdopter_API.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedPK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Domestic", "AdopterID", "dbo.Adopter");
            DropIndex("dbo.Domestic", new[] { "AdopterID" });
            RenameColumn(table: "dbo.Domestic", name: "AdopterID", newName: "Adopter_AdopterId");
            AlterColumn("dbo.Domestic", "Adopter_AdopterId", c => c.Int());
            CreateIndex("dbo.Domestic", "Adopter_AdopterId");
            AddForeignKey("dbo.Domestic", "Adopter_AdopterId", "dbo.Adopter", "AdopterId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Domestic", "Adopter_AdopterId", "dbo.Adopter");
            DropIndex("dbo.Domestic", new[] { "Adopter_AdopterId" });
            AlterColumn("dbo.Domestic", "Adopter_AdopterId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Domestic", name: "Adopter_AdopterId", newName: "AdopterID");
            CreateIndex("dbo.Domestic", "AdopterID");
            AddForeignKey("dbo.Domestic", "AdopterID", "dbo.Adopter", "AdopterId", cascadeDelete: true);
        }
    }
}
