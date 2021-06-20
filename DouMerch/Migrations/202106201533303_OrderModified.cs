namespace DouMerch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderModified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.order", "ItemCount", c => c.Int(nullable: false));
            DropColumn("dbo.order", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.order", "Address", c => c.String());
            DropColumn("dbo.order", "ItemCount");
        }
    }
}
