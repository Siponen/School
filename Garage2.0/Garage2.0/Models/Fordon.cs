using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2._0.Models
{
    public class Fordon
    {
        public int Id { get; set; }
        [Required]
        public string RegNr { get; set; }
        public FordonsTyp Typ { get; set; }
        public FordonsFärg Färg { get; set; }
        [Required]
        public string Märke { get; set; }
        [Required]
        public string Modell { get; set; }
        [Range(0, int.MaxValue)]
        public int AntalHjul { get; set; }
        public DateTime IncheckDatum { get; set; }

        public Fordon()
        {

        }

        public Fordon(FordonsTyp typ, string regNr, FordonsFärg färg, int antalHjul, string märke, string modell)
        {
            Typ = typ;
            RegNr = regNr;
            Färg = färg;
            AntalHjul = antalHjul;
            Märke = märke;
            Modell = modell;
            IncheckDatum = DateTime.Now;
        }

        public Fordon(FordonsTyp typ, string regNr, FordonsFärg färg, int antalHjul, string märke, string modell, DateTime incheckDatum)
        {
            Typ = typ;
            RegNr = regNr;
            Färg = färg;
            AntalHjul = antalHjul;
            Märke = märke;
            Modell = modell;
            IncheckDatum = incheckDatum;
        }
    }
}