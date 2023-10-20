using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RefkaBenceTZ
{
    class Program
    {
        static double EvjaratAtlag(List<Kamion> k)
        {
            var atlag = k.Average(ave => ave.Evjarat);
            return atlag;
        }
        static int F10(List<Kamion> k)
        {
            var MANkaminonok = new List<Kamion>();
            var f10 = k.Where(d => d.Marka == "MAN" && d.Evjarat >= 2018);
            foreach (var i in f10)
            {
                MANkaminonok.Add(i);
            }
            return MANkaminonok.Count;
        }
        static Kamion LegtobbetFutott(List<Kamion> k)
        {
            var f11 = k.OrderByDescending(m => m.KmperOraAllas).First();
            return f11;
        }
        static Kamion F12(List<Kamion> k)
        {
            var mercedes = k.OrderByDescending(d => d.Marka == "Mercedes").First();
            var keresett = k.Where(d => d.Marka == "Iveco" && d.Fogyasztas < mercedes.Loero).First();
            return keresett;
        }
        static List<Kamion> Fogyasztas30lAlatt(List<Kamion> k)
        {    
            var fogyasztas = k.Where(d => d.Fogyasztas < 30).ToList();
            return fogyasztas;
        }
        static void Main(string[] args)
        {
            var kamionok = new List<Kamion>();

            using var sr = new StreamReader(@"..\..\..\src\kamionok.txt");
            _ = sr.ReadLine();
            while (!sr.EndOfStream)
            {
                kamionok.Add(new Kamion(sr.ReadLine()));
            }

            //if (sr != null) sr.Dispose();

            Console.WriteLine("7. feladat");
            foreach (var i in kamionok)
            {
                Console.WriteLine(i.ToString());
            }

            Console.WriteLine("9. feladat");
            Console.WriteLine($"A kamionok átlagos évjárata: {Math.Round(EvjaratAtlag(kamionok))}");

            Console.WriteLine("10. feladat");
            Console.WriteLine($"Összesen {F10(kamionok)} db ilyen kamion van.");

            Console.WriteLine("11. feladat");
            Console.WriteLine($"A legtöbbet futott kamion adatai: {LegtobbetFutott(kamionok)}");

            Console.WriteLine("12. feladat");
            Console.WriteLine("Kamion adatok: ");

            if (F12(kamionok) != null)
            {
                Console.WriteLine(F12(kamionok).ToString());
            }
            else
            {
                Console.WriteLine("Nincs ilyen");
            }

            Console.WriteLine("13. feladat");
            Console.WriteLine("A 30 liter alatti fogyasztású kamionok adatai: ");
            foreach (var i in Fogyasztas30lAlatt(kamionok))
            {
                Console.WriteLine($"\t{i.ToString()}");
            }

            //15. feladat

            var Ujkamionok = new List<Kamion>();
            foreach (var i in kamionok)
            {
                Ujkamionok.Add(i);
            }

            using var sw = new StreamWriter(@"..\..\..\src\Ujkamionok.txt");
            sw.WriteLine("Márka, Típus, Évjárat, Lóerő, Fogyasztás, Km/Óra állás");
            foreach (var i in Ujkamionok)
            {   
                sw.WriteLine(i.ToString());
            }

            //if (sr != null) sr.Dispose();

            Console.ReadKey();
        }
    }
}
