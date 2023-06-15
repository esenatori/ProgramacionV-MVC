namespace Web.MVCMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Actors : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Actor");
        }
    }
}
