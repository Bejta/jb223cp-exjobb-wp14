namespace StreamOneInterface.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration9 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderStatus", "Status", c => c.String(nullable: false));
            AlterColumn("dbo.OrderTypes", "Type", c => c.String(nullable: false));
            AlterColumn("dbo.Resellers", "CustomerID", c => c.String(nullable: false));
            AlterColumn("dbo.Resellers", "Firstname", c => c.String(nullable: false));
            AlterColumn("dbo.Resellers", "Lastname", c => c.String(nullable: false));
            AlterColumn("dbo.Resellers", "Address1", c => c.String(nullable: false));
            AlterColumn("dbo.Resellers", "Address2", c => c.String(nullable: false));
            AlterColumn("dbo.Resellers", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Resellers", "Company", c => c.String(nullable: false));
            AlterColumn("dbo.Resellers", "Website", c => c.String(nullable: false));
            AlterColumn("dbo.Resellers", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Resellers", "Country", c => c.String(nullable: false));
            AlterColumn("dbo.Resellers", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Resellers", "State", c => c.String(nullable: false));
            AlterColumn("dbo.Resellers", "Zip", c => c.String(nullable: false));
            AlterColumn("dbo.OrderRowStatus", "RowStatus", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "StreamOneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "ShareNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Description", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String());
            AlterColumn("dbo.Products", "ShareNumber", c => c.String());
            AlterColumn("dbo.Products", "StreamOneNumber", c => c.String());
            AlterColumn("dbo.OrderRowStatus", "RowStatus", c => c.String());
            AlterColumn("dbo.Resellers", "Zip", c => c.String());
            AlterColumn("dbo.Resellers", "State", c => c.String());
            AlterColumn("dbo.Resellers", "Phone", c => c.String());
            AlterColumn("dbo.Resellers", "Country", c => c.String());
            AlterColumn("dbo.Resellers", "Email", c => c.String());
            AlterColumn("dbo.Resellers", "Website", c => c.String());
            AlterColumn("dbo.Resellers", "Company", c => c.String());
            AlterColumn("dbo.Resellers", "City", c => c.String());
            AlterColumn("dbo.Resellers", "Address2", c => c.String());
            AlterColumn("dbo.Resellers", "Address1", c => c.String());
            AlterColumn("dbo.Resellers", "Lastname", c => c.String());
            AlterColumn("dbo.Resellers", "Firstname", c => c.String());
            AlterColumn("dbo.Resellers", "CustomerID", c => c.String());
            AlterColumn("dbo.OrderTypes", "Type", c => c.String());
            AlterColumn("dbo.OrderStatus", "Status", c => c.String());
        }
    }
}
