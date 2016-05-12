namespace StreamOneInterface.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration4 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.OrderRows", new[] { "OrderRowStatus_Id1" });
            DropIndex("dbo.OrderRows", new[] { "Product_Id1" });
            DropIndex("dbo.Orders", new[] { "OrderStatus_Id1" });
            DropIndex("dbo.Orders", new[] { "OrderType_Id1" });
            DropIndex("dbo.Orders", new[] { "Reseller_Id1" });
            DropIndex("dbo.Orders", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.OrderRows", "OrderRowStatus_Id");
            DropColumn("dbo.OrderRows", "Product_Id");
            DropColumn("dbo.Orders", "OrderStatus_Id");
            DropColumn("dbo.Orders", "OrderType_Id");
            DropColumn("dbo.Orders", "Reseller_Id");
            DropColumn("dbo.Orders", "User_Id");
            RenameColumn(table: "dbo.OrderRows", name: "OrderRowStatus_Id1", newName: "OrderRowStatus_Id");
            RenameColumn(table: "dbo.Orders", name: "OrderStatus_Id1", newName: "OrderStatus_Id");
            RenameColumn(table: "dbo.Orders", name: "OrderType_Id1", newName: "OrderType_Id");
            RenameColumn(table: "dbo.OrderRows", name: "Product_Id1", newName: "Product_Id");
            RenameColumn(table: "dbo.Orders", name: "Reseller_Id1", newName: "Reseller_Id");
            RenameColumn(table: "dbo.Orders", name: "ApplicationUser_Id", newName: "User_Id");
            AlterColumn("dbo.OrderRows", "OrderRowStatus_Id", c => c.Int());
            AlterColumn("dbo.OrderRows", "Product_Id", c => c.Int());
            AlterColumn("dbo.Orders", "User_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Orders", "Reseller_Id", c => c.Int());
            AlterColumn("dbo.Orders", "OrderType_Id", c => c.Int());
            AlterColumn("dbo.Orders", "OrderStatus_Id", c => c.Int());
            CreateIndex("dbo.OrderRows", "OrderRowStatus_Id");
            CreateIndex("dbo.OrderRows", "Product_Id");
            CreateIndex("dbo.Orders", "OrderStatus_Id");
            CreateIndex("dbo.Orders", "OrderType_Id");
            CreateIndex("dbo.Orders", "Reseller_Id");
            CreateIndex("dbo.Orders", "User_Id");
            DropColumn("dbo.OrderRows", "item_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderRows", "item_id", c => c.String());
            DropIndex("dbo.Orders", new[] { "User_Id" });
            DropIndex("dbo.Orders", new[] { "Reseller_Id" });
            DropIndex("dbo.Orders", new[] { "OrderType_Id" });
            DropIndex("dbo.Orders", new[] { "OrderStatus_Id" });
            DropIndex("dbo.OrderRows", new[] { "Product_Id" });
            DropIndex("dbo.OrderRows", new[] { "OrderRowStatus_Id" });
            AlterColumn("dbo.Orders", "OrderStatus_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "OrderType_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "Reseller_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "User_Id", c => c.String());
            AlterColumn("dbo.OrderRows", "Product_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderRows", "OrderRowStatus_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Orders", name: "User_Id", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.Orders", name: "Reseller_Id", newName: "Reseller_Id1");
            RenameColumn(table: "dbo.OrderRows", name: "Product_Id", newName: "Product_Id1");
            RenameColumn(table: "dbo.Orders", name: "OrderType_Id", newName: "OrderType_Id1");
            RenameColumn(table: "dbo.Orders", name: "OrderStatus_Id", newName: "OrderStatus_Id1");
            RenameColumn(table: "dbo.OrderRows", name: "OrderRowStatus_Id", newName: "OrderRowStatus_Id1");
            AddColumn("dbo.Orders", "User_Id", c => c.String());
            AddColumn("dbo.Orders", "Reseller_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "OrderType_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "OrderStatus_Id", c => c.Int(nullable: false));
            AddColumn("dbo.OrderRows", "Product_Id", c => c.Int(nullable: false));
            AddColumn("dbo.OrderRows", "OrderRowStatus_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "ApplicationUser_Id");
            CreateIndex("dbo.Orders", "Reseller_Id1");
            CreateIndex("dbo.Orders", "OrderType_Id1");
            CreateIndex("dbo.Orders", "OrderStatus_Id1");
            CreateIndex("dbo.OrderRows", "Product_Id1");
            CreateIndex("dbo.OrderRows", "OrderRowStatus_Id1");
        }
    }
}
