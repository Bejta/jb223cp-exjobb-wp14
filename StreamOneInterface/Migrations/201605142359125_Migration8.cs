namespace StreamOneInterface.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderRows", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.OrderRows", "OrderRowStatus_Id", "dbo.OrderRowStatus");
            DropForeignKey("dbo.OrderRows", "Product_Id", "dbo.Products");
            DropIndex("dbo.OrderRows", new[] { "Order_Id" });
            DropIndex("dbo.OrderRows", new[] { "OrderRowStatus_Id" });
            DropIndex("dbo.OrderRows", new[] { "Product_Id" });
            RenameColumn(table: "dbo.OrderRows", name: "Order_Id", newName: "OrderID");
            RenameColumn(table: "dbo.OrderRows", name: "OrderRowStatus_Id", newName: "OrderRowStatusID");
            RenameColumn(table: "dbo.OrderRows", name: "Product_Id", newName: "ProductID");
            AddColumn("dbo.OrderRows", "ItemID", c => c.String());
            AddColumn("dbo.Orders", "OrderStreamOneID", c => c.String());
            AddColumn("dbo.Orders", "ListingID", c => c.String());
            AlterColumn("dbo.OrderRows", "OrderID", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderRows", "OrderRowStatusID", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderRows", "ProductID", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderRows", "OrderID");
            CreateIndex("dbo.OrderRows", "OrderRowStatusID");
            CreateIndex("dbo.OrderRows", "ProductID");
            AddForeignKey("dbo.OrderRows", "OrderID", "dbo.Orders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderRows", "OrderRowStatusID", "dbo.OrderRowStatus", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderRows", "ProductID", "dbo.Products", "Id", cascadeDelete: true);
            DropColumn("dbo.Orders", "OrderStreamOne_Id");
            DropColumn("dbo.Orders", "Listing_Id");
            DropTable("dbo.ProductViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StreamOneNumber = c.String(nullable: false),
                        ShareNumber = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Orders", "Listing_Id", c => c.String());
            AddColumn("dbo.Orders", "OrderStreamOne_Id", c => c.String());
            DropForeignKey("dbo.OrderRows", "ProductID", "dbo.Products");
            DropForeignKey("dbo.OrderRows", "OrderRowStatusID", "dbo.OrderRowStatus");
            DropForeignKey("dbo.OrderRows", "OrderID", "dbo.Orders");
            DropIndex("dbo.OrderRows", new[] { "ProductID" });
            DropIndex("dbo.OrderRows", new[] { "OrderRowStatusID" });
            DropIndex("dbo.OrderRows", new[] { "OrderID" });
            AlterColumn("dbo.OrderRows", "ProductID", c => c.Int());
            AlterColumn("dbo.OrderRows", "OrderRowStatusID", c => c.Int());
            AlterColumn("dbo.OrderRows", "OrderID", c => c.Int());
            DropColumn("dbo.Orders", "ListingID");
            DropColumn("dbo.Orders", "OrderStreamOneID");
            DropColumn("dbo.OrderRows", "ItemID");
            RenameColumn(table: "dbo.OrderRows", name: "ProductID", newName: "Product_Id");
            RenameColumn(table: "dbo.OrderRows", name: "OrderRowStatusID", newName: "OrderRowStatus_Id");
            RenameColumn(table: "dbo.OrderRows", name: "OrderID", newName: "Order_Id");
            CreateIndex("dbo.OrderRows", "Product_Id");
            CreateIndex("dbo.OrderRows", "OrderRowStatus_Id");
            CreateIndex("dbo.OrderRows", "Order_Id");
            AddForeignKey("dbo.OrderRows", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.OrderRows", "OrderRowStatus_Id", "dbo.OrderRowStatus", "Id");
            AddForeignKey("dbo.OrderRows", "Order_Id", "dbo.Orders", "Id");
        }
    }
}
