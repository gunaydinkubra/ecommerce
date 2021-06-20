namespace DouMerch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class category : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.category",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        Imageurl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.order",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                        Address = c.String(),
                        ProductId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.product",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CategoryId = c.Long(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        ImageUrl = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.order", "UserId", "dbo.users");
            DropForeignKey("dbo.order", "ProductId", "dbo.product");
            DropForeignKey("dbo.product", "CategoryId", "dbo.category");
            DropIndex("dbo.product", new[] { "CategoryId" });
            DropIndex("dbo.order", new[] { "ProductId" });
            DropIndex("dbo.order", new[] { "UserId" });
            DropTable("dbo.product");
            DropTable("dbo.order");
            DropTable("dbo.category");
        }
    }
}
