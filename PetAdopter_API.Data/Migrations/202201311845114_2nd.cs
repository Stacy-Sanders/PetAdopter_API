namespace PetAdopter_API.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2nd : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Domestic", new[] { "AdopterID" });
            CreateIndex("dbo.Domestic", "AdopterId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Domestic", new[] { "AdopterId" });
            CreateIndex("dbo.Domestic", "AdopterID");
        }
    }
}
