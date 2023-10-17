using System;
using System.Collections.Generic;
using System.Text;

namespace RefkaBenceTZ
{
    class Kamion
    {
        public string Marka { get; set; }
        public string Tipus { get; set; }
        public int Evjarat { get; set; }
        public int Loero { get; set; }
        public double Fogyasztas { get; set; }
        public int KmperOraAllas { get; set; }
        //14.feladat
        public double KW {
            get
            {
                return Loero * 0.7355;
            }
        }

        public Kamion(string s)
        {
            var v = s.Split(';');
            this.Marka = v[0];
            this.Tipus = v[1];
            this.Evjarat = int.Parse(v[2]);
            this.Loero = int.Parse(v[3]);
            this.Fogyasztas = double.Parse(v[4]);
            this.KmperOraAllas = int.Parse(v[5]);
        }

        public override string ToString()
        {
            return $"{Marka}, {Tipus}, {Evjarat}, {Loero}, {Fogyasztas}, {KmperOraAllas}";
        }


    }
}
