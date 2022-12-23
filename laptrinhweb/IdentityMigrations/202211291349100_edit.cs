namespace laptrinhweb.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Address", c => c.String());
            DropColumn("dbo.AspNetUsers", "Addess");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Addess", c => c.String());
            DropColumn("dbo.AspNetUsers", "Address");
        }
    }
}
