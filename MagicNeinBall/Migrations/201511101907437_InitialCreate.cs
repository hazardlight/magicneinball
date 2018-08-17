namespace MagicNeinBall.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fortunes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        fortuneText = c.String(),
                        rIndex = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Fortunes");
        }
    }
}
