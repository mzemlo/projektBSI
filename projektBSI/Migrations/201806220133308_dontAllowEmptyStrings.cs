namespace projektBSI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dontAllowEmptyStrings : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Signature", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Signature", c => c.String());
        }
    }
}
