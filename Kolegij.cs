using System;
using System.Collections.Generic;
using System.Text;

namespace Upisi
{
    class Kolegij
    {
        public readonly string sifra, naziv;
        public readonly int ects;

        public override bool Equals(object obj)
        {
            return obj is Kolegij && Equals(obj);
        }
        public bool Equals(Kolegij obj)
        {
            return sifra == obj.sifra;
        }
    }
}
