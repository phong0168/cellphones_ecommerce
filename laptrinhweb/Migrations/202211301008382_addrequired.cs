namespace laptrinhweb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SanPhams", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.SanPhams", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.SanPhams", "ImageUrl", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SanPhams", "ImageUrl", c => c.String());
            AlterColumn("dbo.SanPhams", "Description", c => c.String());
            AlterColumn("dbo.SanPhams", "Name", c => c.String());
        }
    }
}
