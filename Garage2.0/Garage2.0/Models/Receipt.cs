using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2._0.Models
{
    public class Receipt
    {
        public string RegNr { get; set; }
        public DateTime IncheckDatum { get; set; }
        public DateTime UtcheckDatum { get; set; }
        public int Kostnad { get; private set; }

        public Receipt()
        {
            RegNr = "Base";
            IncheckDatum = DateTime.Now;
            UtcheckDatum = DateTime.Now;
        }

        public Receipt(string regNr, DateTime incheckDatum, DateTime utcheckDatum)
        {
            RegNr = regNr;
            IncheckDatum = incheckDatum;
            UtcheckDatum = utcheckDatum;
            CalculatePrice();
        }

        void CalculatePrice()
        {
            const int HoursPerDay = 24;
            const int costPerHour = 60;
            const float numMinutesInHour = 60;

            int daysStayed = Math.Abs(UtcheckDatum.DayOfYear - IncheckDatum.DayOfYear);
            int numHoursStayedCost = costPerHour * ((daysStayed*HoursPerDay) + UtcheckDatum.Hour );

            float minutesStayed = ((float) UtcheckDatum.Minute / numMinutesInHour);
            int minuteStayedCost = Convert.ToInt32(costPerHour * minutesStayed);
            float minuteOffset = ((float) IncheckDatum.Minute / numMinutesInHour);
            int minuteCostOffset = Convert.ToInt32(costPerHour*minuteOffset);

            int firstDayOffset = (IncheckDatum.Hour * costPerHour) + minuteCostOffset;
            Kostnad = numHoursStayedCost + minuteStayedCost - firstDayOffset;
        }
    }
}