namespace HGINF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IpPCnum : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IpPCnums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IP = c.String(),
                        PCnum = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.IpPCnums");
        }
    }
}
