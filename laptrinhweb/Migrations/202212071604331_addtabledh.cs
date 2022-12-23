namespace laptrinhweb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtabledh : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DatHangs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShipName = c.String(nullable: false),
                        ShipAddress = c.String(nullable: false),
                        ShipPhoneNumber = c.String(nullable: false),
                        ShipEmail = c.String(),
                        SanPhamId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SanPhams", t => t.SanPhamId, cascadeDelete: true)
                .Index(t => t.SanPhamId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DatHangs", "SanPhamId", "dbo.SanPhams");
            DropIndex("dbo.DatHangs", new[] { "SanPhamId" });
            DropTable("dbo.DatHangs");
        }
    }
}
