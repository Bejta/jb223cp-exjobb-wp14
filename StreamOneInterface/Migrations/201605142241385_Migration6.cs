namespace StreamOneInterface.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "OrderStatus_Id", "dbo.OrderStatus");
            DropForeignKey("dbo.Orders", "OrderType_Id", "dbo.OrderTypes");
            DropForeignKey("dbo.Orders", "Reseller_Id", "dbo.Resellers");
            DropIndex("dbo.Orders", new[] { "OrderStatus_Id" });
            DropIndex("dbo.Orders", new[] { "OrderType_Id" });
            DropIndex("dbo.Orders", new[] { "Reseller_Id" });
            RenameColumn(table: "dbo.Orders", name: "OrderStatus_Id", newName: "OrderStatusID");
            RenameColumn(table: "dbo.Orders", name: "OrderType_Id", newName: "OrderTypeID");
            RenameColumn(table: "dbo.Orders", name: "Reseller_Id", newName: "ResellerID");
            RenameColumn(table: "dbo.Orders", name: "User_Id", newName: "UserID");
            RenameIndex(table: "dbo.Orders", name: "IX_User_Id", newName: "IX_UserID");
            AddColumn("dbo.Orders", "TimeStamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AlterColumn("dbo.Orders", "OrderStatusID", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "OrderTypeID", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "ResellerID", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "ResellerID");
            CreateIndex("dbo.Orders", "OrderTypeID");
            CreateIndex("dbo.Orders", "OrderStatusID");
            AddForeignKey("dbo.Orders", "OrderStatusID", "dbo.OrderStatus", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "OrderTypeID", "dbo.OrderTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "ResellerID", "dbo.Resellers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ResellerID", "dbo.Resellers");
            DropForeignKey("dbo.Orders", "OrderTypeID", "dbo.OrderTypes");
            DropForeignKey("dbo.Orders", "OrderStatusID", "dbo.OrderStatus");
            DropIndex("dbo.Orders", new[] { "OrderStatusID" });
            DropIndex("dbo.Orders", new[] { "OrderTypeID" });
            DropIndex("dbo.Orders", new[] { "ResellerID" });
            AlterColumn("dbo.Orders", "ResellerID", c => c.Int());
            AlterColumn("dbo.Orders", "OrderTypeID", c => c.Int());
            AlterColumn("dbo.Orders", "OrderStatusID", c => c.Int());
            DropColumn("dbo.Orders", "TimeStamp");
            RenameIndex(table: "dbo.Orders", name: "IX_UserID", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Orders", name: "UserID", newName: "User_Id");
            RenameColumn(table: "dbo.Orders", name: "ResellerID", newName: "Reseller_Id");
            RenameColumn(table: "dbo.Orders", name: "OrderTypeID", newName: "OrderType_Id");
            RenameColumn(table: "dbo.Orders", name: "OrderStatusID", newName: "OrderStatus_Id");
            CreateIndex("dbo.Orders", "Reseller_Id");
            CreateIndex("dbo.Orders", "OrderType_Id");
            CreateIndex("dbo.Orders", "OrderStatus_Id");
            AddForeignKey("dbo.Orders", "Reseller_Id", "dbo.Resellers", "Id");
            AddForeignKey("dbo.Orders", "OrderType_Id", "dbo.OrderTypes", "Id");
            AddForeignKey("dbo.Orders", "OrderStatus_Id", "dbo.OrderStatus", "Id");
        }
    }
}
