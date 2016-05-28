namespace StreamOneInterface.Migrations
{
    using Models.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StreamOneInterface.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StreamOneInterface.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

            var products = new List<Product>
            {
                new Product { StreamOneNumber = "1001",   ShareNumber = "RSEVUC0033",
                    Name = "Personal VMR", Description="Personal Virtual Meeting Room", Active = true },
                new Product {  StreamOneNumber = "1002",   ShareNumber = "RSEVUC0033",
                    Name = "Codec VMR", Description="Virtual Meeting Room for Codec", Active = true},
                new Product {  StreamOneNumber = "1003",   ShareNumber = "RSEVUC0013",
                    Name = "VMR-bundled CloudVision", Description="CloudVision interface to be bundled with a VMR subscription", Active = true },
                new Product {  StreamOneNumber = "392",   ShareNumber = "RSEVUC0014",
                    Name = "My App Install Main Item", Description="My App Install Main Item", Active = true},
                 new Product {  StreamOneNumber = "393",   ShareNumber = "RSEVUC0015",
                    Name = "My App Install Main Item", Description="My App Install Sub Item", Active = true},
            };
            products.ForEach(s => context.Products.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();

            var statuses = new List<OrderStatus>
            {
                new OrderStatus {Status = "Completed Successfully"},
                new OrderStatus {Status = "Still In Process"},
                new OrderStatus {Status = "Not Yet Applicable"},
                new OrderStatus {Status = "Awaiting User Action"},
                new OrderStatus {Status = "Error Occurred"},
                new OrderStatus {Status = "Order on hold"},
                new OrderStatus {Status = "Cancelled"}
            };
            statuses.ForEach(s => context.OrderStatus.AddOrUpdate(p => p.Status, s));
            context.SaveChanges();

            var rowStatuses = new List<OrderRowStatus>
            {
                new OrderRowStatus {RowStatus = "Completed Successfully"},
                new OrderRowStatus {RowStatus = "Still In Process"},
                new OrderRowStatus {RowStatus = "Not Yet Applicable"},
                new OrderRowStatus {RowStatus = "Awaiting User Action"},
                new OrderRowStatus {RowStatus = "Error Occurred"},
                new OrderRowStatus {RowStatus = "Product on hold"},
                new OrderRowStatus {RowStatus = "Cancelled"}
            };
            rowStatuses.ForEach(s => context.OrderRowStatus.AddOrUpdate(p => p.RowStatus, s));
            context.SaveChanges();

            var types = new List<OrderType>
            {
                new OrderType {Type = "StreamOne Order"},
                new OrderType {Type = "Provisional Order"},
                new OrderType {Type = "Periodical Order"},

            };
            types.ForEach(s => context.OrderTypes.AddOrUpdate(p => p.Type, s));
            context.SaveChanges();

            var resellers = new List<Reseller>
            {
                new Reseller {
                    CustomerID="03673b3ffe1d66a92767d",
                    Address1= "2000 Mill Ave S",
                    Address2= "Suite400",
                    City= "Renton",
                    Company= "MyCoInc.",
                    Website= "example.com",
                    Country= "US",
                    Email="John.Smith@tdstreamone.eu",
                    Firstname= "John",
                    Lastname= "Smith",
                    Phone = "4255553888",
                    State= "WA",
                    Zip= "98055",
               },
                new Reseller
                {
                    CustomerID = "03673testtesttest",
                    Address1 = "4000 Mill Ave S",
                    Address2 = "Suite200",
                    City = "Lund",
                    Company = "MyCompany",
                    Website = "www.lund.com",
                    Country = "US",
                    Email = "Kalle.Anka@tdstreamone.eu",
                    Firstname = "Kalle",
                    Lastname = "Anka",
                    Phone = "42555ss88",
                    State = "--",
                    Zip = "12345",
                }
            };
            resellers.ForEach(s => context.Resellers.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();


            var orders = new List<Order>
            {
                new Order{
                    OrderStreamOneID="b0080cad6b39b50ced361f5d7aa82aec",
                    ListingID="2448",
                    Date= DateTime.Now,
                    //OrderStatusID = statuses.Single(s => s.Status == "Completed Successfully").Id,
                    //OrderTypeID = types.Single(s => s.Id == 1).Id,
                    //ResellerID = resellers.Single(s => s.Zip == "98055").Id,
                     OrderStatusID = 1,
                    OrderTypeID =2,
                    ResellerID =1,
                },
                 new Order {
                    OrderStreamOneID="testtesttest",
                    ListingID="2449",
                    Date= DateTime.Now,
                    //OrderStatusID = statuses.Single(s => s.Status == "Still In Process").Id,
                    //OrderTypeID = types.Single(s => s.Id == 1).Id,
                    //ResellerID = resellers.Single(s => s.Zip == "12345").Id,
                     OrderStatusID = 1,
                    OrderTypeID =2,
                    ResellerID =1,
                 },
            };
            orders.ForEach(s => context.Orders.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();

            var orderRows = new List<OrderRow>
            {
                new OrderRow
                {
                    OrderID=orders.SingleOrDefault(s => s.OrderStreamOneID == "testtesttest").Id,
                    ItemID= "5a25-­‐d0c8-­‐267c-­‐01d1-­‐541f",
                    ProductID= products.SingleOrDefault(s => s.StreamOneNumber == "392").Id,
                    StreamOneID= products.SingleOrDefault(s => s.StreamOneNumber == "392").StreamOneNumber,
                    OrderRowStatusID= rowStatuses.SingleOrDefault(s => s.RowStatus == "Product on hold").Id,
                    Quantity= 1,
                    Description = products.SingleOrDefault(s => s.StreamOneNumber == "392").Description,
                    UnitPrice= Convert.ToSingle(12.00),
                },
                new OrderRow
                {
                    OrderID=orders.SingleOrDefault(s => s.OrderStreamOneID == "testtesttest").Id,
                    ItemID= "5a25-­‐d0c8-­‐267c-­‐01d1-­‐TEST",
                    ProductID= 1,
                    StreamOneID= products.SingleOrDefault(s => s.StreamOneNumber == "393").StreamOneNumber,
                    OrderRowStatusID= rowStatuses.SingleOrDefault(s => s.RowStatus == "Not Yet Applicable").Id,
                    Quantity= 2,
                    Description = products.SingleOrDefault(s => s.StreamOneNumber == "393").Description,
                    UnitPrice= Convert.ToSingle(12.00),
                },
                new OrderRow
                {

                    OrderID=orders.SingleOrDefault(s => s.OrderStreamOneID == "b0080cad6b39b50ced361f5d7aa82aec").Id,
                    ItemID= "5a25-­‐d0c8-­‐TEST-­‐TEST-­‐TEST",
                    ProductID= products.SingleOrDefault(s => s.StreamOneNumber == "1002").Id,
                    StreamOneID= products.SingleOrDefault(s => s.StreamOneNumber == "1002").StreamOneNumber,
                    OrderRowStatusID= rowStatuses.SingleOrDefault(s => s.RowStatus == "Product on hold").Id,
                    Quantity=2,
                    Description = products.SingleOrDefault(s => s.StreamOneNumber == "1002").Description,
                    UnitPrice= Convert.ToSingle(12.00),
                },
                new OrderRow
                {
                    OrderID=orders.SingleOrDefault(s => s.OrderStreamOneID == "b0080cad6b39b50ced361f5d7aa82aec").Id,
                    ItemID= "5a25-­‐d0c8-­‐TEST-­‐TEST",
                    ProductID= products.SingleOrDefault(s => s.StreamOneNumber == "1003").Id,
                     StreamOneID= products.SingleOrDefault(s => s.StreamOneNumber == "1003").StreamOneNumber,
                    OrderRowStatusID= rowStatuses.SingleOrDefault(s => s.RowStatus == "Not Yet Applicable").Id,
                    Quantity=1,
                    Description = products.SingleOrDefault(s => s.StreamOneNumber == "1003").Description,
                    UnitPrice= Convert.ToSingle(12.00),
                },
                new OrderRow
                {
                    OrderID=orders.SingleOrDefault(s => s.OrderStreamOneID == "b0080cad6b39b50ced361f5d7aa82aec").Id,
                    ItemID= "5a25-­‐d0c8-­‐TEST--NEW",
                    ProductID= products.SingleOrDefault(s => s.StreamOneNumber == "1001").Id,
                     StreamOneID= products.SingleOrDefault(s => s.StreamOneNumber == "1001").StreamOneNumber,
                    OrderRowStatusID= rowStatuses.SingleOrDefault(s => s.RowStatus == "Product on hold").Id,
                    Quantity=1,
                    Description = products.SingleOrDefault(s => s.StreamOneNumber == "1001").Description,
                    UnitPrice= Convert.ToSingle(12.00),
                },
            };
            orderRows.ForEach(s => context.OrderRows.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();
        }
    }
}
