namespace HGINF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequestNomPC : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requests", "NomPC", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Requests", "NomPC");
        }
    }
}
