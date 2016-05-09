namespace StreamOneInterface.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "OrderRowStatus_Id", "dbo.OrderRowStatus");
            DropForeignKey("dbo.Orders", "Product_Id", "dbo.Products");
            DropIndex("dbo.Orders", new[] { "OrderRowStatus_Id" });
            DropIndex("dbo.Orders", new[] { "Product_Id" });
            AddColumn("dbo.OrderRows", "OrderRowStatus_Id1", c => c.Int());
            AddColumn("dbo.OrderRows", "Product_Id1", c => c.Int());
            CreateIndex("dbo.OrderRows", "OrderRowStatus_Id1");
            CreateIndex("dbo.OrderRows", "Product_Id1");
            AddForeignKey("dbo.OrderRows", "OrderRowStatus_Id1", "dbo.OrderRowStatus", "Id");
            AddForeignKey("dbo.OrderRows", "Product_Id1", "dbo.Products", "Id");
            DropColumn("dbo.Orders", "OrderRowStatus_Id");
            DropColumn("dbo.Orders", "Product_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Product_Id", c => c.Int());
            AddColumn("dbo.Orders", "OrderRowStatus_Id", c => c.Int());
            DropForeignKey("dbo.OrderRows", "Product_Id1", "dbo.Products");
            DropForeignKey("dbo.OrderRows", "OrderRowStatus_Id1", "dbo.OrderRowStatus");
            DropIndex("dbo.OrderRows", new[] { "Product_Id1" });
            DropIndex("dbo.OrderRows", new[] { "OrderRowStatus_Id1" });
            DropColumn("dbo.OrderRows", "Product_Id1");
            DropColumn("dbo.OrderRows", "OrderRowStatus_Id1");
            CreateIndex("dbo.Orders", "Product_Id");
            CreateIndex("dbo.Orders", "OrderRowStatus_Id");
            AddForeignKey("dbo.Orders", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.Orders", "OrderRowStatus_Id", "dbo.OrderRowStatus", "Id");
        }
    }
}
