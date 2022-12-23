namespace laptrinhweb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChuDes",
                c => new
                    {
                        ChuDeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ChuDeId);
            
            CreateTable(
                "dbo.SanPhams",
                c => new
                    {
                        SanPhamId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Single(nullable: false),
                        Description = c.String(),
                        ImageUrl = c.String(),
                        ThuongHieuId = c.Int(nullable: false),
                        ChuDeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SanPhamId)
                .ForeignKey("dbo.ChuDes", t => t.ChuDeId, cascadeDelete: true)
                .ForeignKey("dbo.ThuongHieux", t => t.ThuongHieuId, cascadeDelete: true)
                .Index(t => t.ThuongHieuId)
                .Index(t => t.ChuDeId);
            
            CreateTable(
                "dbo.ThuongHieux",
                c => new
                    {
                        ThuongHieuId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ThuongHieuId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SanPhams", "ThuongHieuId", "dbo.ThuongHieux");
            DropForeignKey("dbo.SanPhams", "ChuDeId", "dbo.ChuDes");
            DropIndex("dbo.SanPhams", new[] { "ChuDeId" });
            DropIndex("dbo.SanPhams", new[] { "ThuongHieuId" });
            DropTable("dbo.ThuongHieux");
            DropTable("dbo.SanPhams");
            DropTable("dbo.ChuDes");
        }
    }
}
