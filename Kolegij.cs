using System;
using System.Collections.Generic;
using System.Text;

namespace Upisi
{
    class Kolegij
    {
        public readonly string sifra, naziv;
        public readonly int ects;

        public override bool Equals(object? obj)
        {
            return obj is Kolegij && Equals(obj);
        }
        public bool Equals(Kolegij obj)
        {
            return sifra == obj.sifra;
        }
        public override int GetHashCode()
        {
            return sifra.GetHashCode();
        }
        public override string ToString()
        {
            return $"{naziv} ({sifra}, {ects})";
        }

        public Kolegij(string sifra, string naziv, int ects)
        {
            this.sifra = sifra;
            this.naziv = naziv;
            this.ects = ects;
        }
    }
}
