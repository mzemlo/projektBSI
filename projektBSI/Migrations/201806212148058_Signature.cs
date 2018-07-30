namespace projektBSI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Signature : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Signature", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Signature");
        }
    }
}
