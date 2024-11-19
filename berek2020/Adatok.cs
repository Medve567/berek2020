using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace berek2020
{
    internal class Adatok
    {
        public string Nev { get; set; }
        public bool Nem { get; set; }
        public string Szakma { get; set; }
        public int Belepes { get; set; }
        public int Ber { get; set; }

        public Adatok(string sor)
        {
            var v = sor.Split(';');
            Nev = v[0];
            Nem = v[1] == "férfi";
            Szakma = v[2];
            Belepes = int.Parse(v[3]);
            Ber = int.Parse(v[4]);
        }
        public override string ToString()
        {
            return $"Név: {Nev} | Neme: {(Nem ? "férfi" : "nő")} | Szakma: {Szakma} | Belépés: {Belepes} | Bér: {Ber}";
        }
    }
}
