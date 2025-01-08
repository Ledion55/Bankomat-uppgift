//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection.Metadata.Ecma335;
//using System.Text;
//using System.Threading.Channels;
//using System.Threading.Tasks;

//namespace Bankomat_uppgift
//{
//    public class Bankmotorn
//    {


//        public string kontonummerr { get; set; }
//        public double saldo { get; set; }

//        public Bankmotorn(string kontonummer)
//        {
//            kontonummerr = kontonummer;
//            saldo = 0;
//        }


//        public void Insättning(double belopp)
//        {

//            if (belopp >= 0)

//            {
//                saldo += belopp;
//            }
//            else
//            {
//                Console.WriteLine("Felaktigt belopp, försök igen");

//            }


//        }

//        public void uttag(double belopp)
//        {
//            if (belopp > 0 && belopp <= saldo)
//            {
//                saldo -= belopp;
//            }
//            else
//            {
//                Console.WriteLine("Felaktigt belopp, försök igen");
//            }
//        }

//    }
//}
