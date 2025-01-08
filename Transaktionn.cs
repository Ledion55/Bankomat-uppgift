using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat_uppgift
{


    public class Transaktion
    {
        public string Kontonummer { get; set; }
        public string Typ { get; set; } // "Insättning" eller "Uttag"
        public double Belopp { get; set; }
        public DateTime Datum { get; set; }

        public Transaktion(string kontonummer, string typ, double belopp)
        {
            Kontonummer = kontonummer;
            Typ = typ;
            Belopp = belopp;
            Datum = DateTime.Now;
        }
    }


}
