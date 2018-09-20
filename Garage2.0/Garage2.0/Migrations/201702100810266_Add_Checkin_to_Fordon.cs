namespace Garage2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Checkin_to_Fordon : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fordons", "IncheckDatum", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Fordons", "RegNr", c => c.String(nullable: false));
            AlterColumn("dbo.Fordons", "Märke", c => c.String(nullable: false));
            AlterColumn("dbo.Fordons", "Modell", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Fordons", "Modell", c => c.String());
            AlterColumn("dbo.Fordons", "Märke", c => c.String());
            AlterColumn("dbo.Fordons", "RegNr", c => c.String());
            DropColumn("dbo.Fordons", "IncheckDatum");
        }
    }
}
