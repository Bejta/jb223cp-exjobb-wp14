namespace StreamOneInterface.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addmigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderRows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        item_id = c.String(),
                        Product_Id = c.Int(nullable: false),
                        Description = c.String(),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Single(nullable: false),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.OrderRowStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RowStatus = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Id = c.Int(nullable: false),
                        OrderStreamOne_Id = c.String(),
                        Listing_Id = c.String(),
                        Reseller_Id = c.Int(nullable: false),
                        OrderType_Id = c.Int(nullable: false),
                        OrderStatus_Id = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        OrderRowStatus_Id = c.Int(),
                        OrderStatus_Id1 = c.Int(),
                        OrderType_Id1 = c.Int(),
                        Product_Id = c.Int(),
                        Reseller_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderRowStatus", t => t.OrderRowStatus_Id)
                .ForeignKey("dbo.OrderStatus", t => t.OrderStatus_Id1)
                .ForeignKey("dbo.OrderTypes", t => t.OrderType_Id1)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .ForeignKey("dbo.Resellers", t => t.Reseller_Id1)
                .Index(t => t.OrderRowStatus_Id)
                .Index(t => t.OrderStatus_Id1)
                .Index(t => t.OrderType_Id1)
                .Index(t => t.Product_Id)
                .Index(t => t.Reseller_Id1);
            
            CreateTable(
                "dbo.OrderStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StreamOneNumber = c.String(),
                        ShareNumber = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Resellers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerID = c.String(),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        Company = c.String(),
                        Website = c.String(),
                        Email = c.String(),
                        Country = c.String(),
                        Phone = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Reseller_Id1", "dbo.Resellers");
            DropForeignKey("dbo.Orders", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Orders", "OrderType_Id1", "dbo.OrderTypes");
            DropForeignKey("dbo.Orders", "OrderStatus_Id1", "dbo.OrderStatus");
            DropForeignKey("dbo.Orders", "OrderRowStatus_Id", "dbo.OrderRowStatus");
            DropForeignKey("dbo.OrderRows", "Order_Id", "dbo.Orders");
            DropIndex("dbo.Orders", new[] { "Reseller_Id1" });
            DropIndex("dbo.Orders", new[] { "Product_Id" });
            DropIndex("dbo.Orders", new[] { "OrderType_Id1" });
            DropIndex("dbo.Orders", new[] { "OrderStatus_Id1" });
            DropIndex("dbo.Orders", new[] { "OrderRowStatus_Id" });
            DropIndex("dbo.OrderRows", new[] { "Order_Id" });
            DropTable("dbo.Resellers");
            DropTable("dbo.Products");
            DropTable("dbo.OrderTypes");
            DropTable("dbo.OrderStatus");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderRowStatus");
            DropTable("dbo.OrderRows");
        }
    }
}
