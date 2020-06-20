namespace HGINF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequestCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requests", "Category", c => c.String());
            DropColumn("dbo.Requests", "StrPC");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Requests", "StrPC", c => c.String());
            DropColumn("dbo.Requests", "Category");
        }
    }
}
