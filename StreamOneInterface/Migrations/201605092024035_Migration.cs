namespace StreamOneInterface.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderRows", "OrderRowStatus_Id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderRows", "OrderRowStatus_Id");
        }
    }
}
