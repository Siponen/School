namespace Garage2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fordons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Typ = c.Int(nullable: false),
                        RegNr = c.String(),
                        Färg = c.Int(nullable: false),
                        AntalHjul = c.Int(nullable: false),
                        Märke = c.String(),
                        Modell = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Fordons");
        }
    }
}
