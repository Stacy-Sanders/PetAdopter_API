namespace PetAdopter_API.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3rd : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Exotic", new[] { "AdopterID" });
            CreateIndex("dbo.Exotic", "AdopterId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Exotic", new[] { "AdopterId" });
            CreateIndex("dbo.Exotic", "AdopterID");
        }
    }
}
