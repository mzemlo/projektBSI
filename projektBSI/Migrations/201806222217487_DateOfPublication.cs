namespace projektBSI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateOfPublication : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "DateOfPublication", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "DateOfPublication");
        }
    }
}
