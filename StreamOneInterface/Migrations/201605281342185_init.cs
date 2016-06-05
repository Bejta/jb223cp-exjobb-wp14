namespace StreamOneInterface.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderRows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        OrderRowStatusID = c.Int(nullable: false),
                        ItemID = c.String(nullable: false),
                        ProductID = c.Int(nullable: false),
                        StreamOneID = c.String(nullable: false),
                        Description = c.String(nullable: false, maxLength: 400),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.OrderRowStatus", t => t.OrderRowStatusID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.OrderRowStatusID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserID = c.String(maxLength: 128),
                        OrderStreamOneID = c.String(),
                        ListingID = c.String(),
                        ResellerID = c.Int(nullable: false),
                        OrderTypeID = c.Int(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        OrderStatusID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .ForeignKey("dbo.OrderStatus", t => t.OrderStatusID, cascadeDelete: true)
                .ForeignKey("dbo.OrderTypes", t => t.OrderTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Resellers", t => t.ResellerID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.ResellerID)
                .Index(t => t.OrderTypeID)
                .Index(t => t.OrderStatusID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.OrderStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Resellers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerID = c.String(nullable: false),
                        Firstname = c.String(nullable: false, maxLength: 100),
                        Lastname = c.String(nullable: false, maxLength: 100),
                        Address1 = c.String(nullable: false, maxLength: 100),
                        Address2 = c.String(),
                        City = c.String(),
                        Company = c.String(nullable: false, maxLength: 100),
                        Website = c.String(),
                        Email = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        State = c.String(),
                        Phone = c.String(),
                        Zip = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderRowStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RowStatus = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StreamOneNumber = c.String(nullable: false, maxLength: 100),
                        ShareNumber = c.String(nullable: false, maxLength: 100),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 1000),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.OrderRows", "ProductID", "dbo.Products");
            DropForeignKey("dbo.OrderRows", "OrderRowStatusID", "dbo.OrderRowStatus");
            DropForeignKey("dbo.OrderRows", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "ResellerID", "dbo.Resellers");
            DropForeignKey("dbo.Orders", "OrderTypeID", "dbo.OrderTypes");
            DropForeignKey("dbo.Orders", "OrderStatusID", "dbo.OrderStatus");
            DropForeignKey("dbo.Orders", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Orders", new[] { "OrderStatusID" });
            DropIndex("dbo.Orders", new[] { "OrderTypeID" });
            DropIndex("dbo.Orders", new[] { "ResellerID" });
            DropIndex("dbo.Orders", new[] { "UserID" });
            DropIndex("dbo.OrderRows", new[] { "ProductID" });
            DropIndex("dbo.OrderRows", new[] { "OrderRowStatusID" });
            DropIndex("dbo.OrderRows", new[] { "OrderID" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Products");
            DropTable("dbo.OrderRowStatus");
            DropTable("dbo.Resellers");
            DropTable("dbo.OrderTypes");
            DropTable("dbo.OrderStatus");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderRows");
        }
    }
}
