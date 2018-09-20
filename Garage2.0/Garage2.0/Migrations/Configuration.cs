namespace Garage2._0.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Garage2._0.DataAccessLayer.FordonsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Garage2._0.DataAccessLayer.FordonsContext context)
        {
            //  This method will be called after migrating to the latest version.W
            context.Fordons.AddOrUpdate(new Fordon(FordonsTyp.Airplane, "ABC123", FordonsF�rg.Black, 4, "Fokker", "Airbus A320"));
            context.Fordons.AddOrUpdate(new Fordon(FordonsTyp.Buss, "DEF456", FordonsF�rg.Blue, 4, "Scania", "H59"));
            context.Fordons.AddOrUpdate(new Fordon(FordonsTyp.Car, "GHJ789", FordonsF�rg.Gold, 4, "Volvo", "V70"));
            context.Fordons.AddOrUpdate(new Fordon(FordonsTyp.Train, "KLM012", FordonsF�rg.Green, 4, "InterCity", "X2000" ));
            context.Fordons.AddOrUpdate(new Fordon(FordonsTyp.Truck, "NOP345", FordonsF�rg.Orange, 8, "Gaffeltruck", "Dubbel"));
        }
    }
}
