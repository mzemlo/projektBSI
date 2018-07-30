namespace projektBSI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removingUnnecessary : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Czlowieks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Czlowieks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Imie = c.String(),
                        Nazwisko = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
