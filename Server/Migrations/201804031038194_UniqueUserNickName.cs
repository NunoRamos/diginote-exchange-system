namespace Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UniqueUserNickName : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Diginotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FacialValue = c.Single(nullable: false),
                        Owner_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Owner_Id, cascadeDelete: true)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Quote = c.Single(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        CreatedBy_Id = c.Int(nullable: false),
                        Transaction_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedBy_Id, cascadeDelete: true)
                .ForeignKey("dbo.Diginotes", t => t.Id)
                .ForeignKey("dbo.Transactions", t => t.Transaction_Id)
                .Index(t => t.Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.Transaction_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Nickname = c.String(nullable: false, maxLength: 20),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Nickname, unique: true);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedAt = c.DateTime(nullable: false),
                        PurchaseOrder_Id = c.Int(nullable: false),
                        SellOrder_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.PurchaseOrder_Id)
                .ForeignKey("dbo.Orders", t => t.SellOrder_Id)
                .Index(t => t.PurchaseOrder_Id)
                .Index(t => t.SellOrder_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Diginotes", "Owner_Id", "dbo.Users");
            DropForeignKey("dbo.Orders", "Transaction_Id", "dbo.Transactions");
            DropForeignKey("dbo.Transactions", "SellOrder_Id", "dbo.Orders");
            DropForeignKey("dbo.Transactions", "PurchaseOrder_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Id", "dbo.Diginotes");
            DropForeignKey("dbo.Orders", "CreatedBy_Id", "dbo.Users");
            DropIndex("dbo.Transactions", new[] { "SellOrder_Id" });
            DropIndex("dbo.Transactions", new[] { "PurchaseOrder_Id" });
            DropIndex("dbo.Users", new[] { "Nickname" });
            DropIndex("dbo.Orders", new[] { "Transaction_Id" });
            DropIndex("dbo.Orders", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Orders", new[] { "Id" });
            DropIndex("dbo.Diginotes", new[] { "Owner_Id" });
            DropTable("dbo.Transactions");
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.Diginotes");
        }
    }
}
