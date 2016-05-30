namespace StreamOneInterface.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "LastUpdated", c => c.DateTime(nullable: false));
            DropColumn("dbo.Orders", "TimeStamp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "TimeStamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            DropColumn("dbo.Orders", "LastUpdated");
        }
    }
}
