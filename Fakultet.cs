using System;
using System.Collections.Generic;
using System.Text;

namespace Upisi
{
    class Fakultet
    {
        public readonly string naziv;
        public readonly Dictionary<Kolegij, List<Student>> upisi;

        public int BrojStudenata
        {
            get {
                HashSet<Student> ukupno = new HashSet<Student>();
                foreach (List<Student> studenti in upisi.Values)
                    ukupno.UnionWith(studenti);
                return ukupno.Count;
            }
        }
        public List<Student> this[string sifra]
        {
            get
            {
                foreach (KeyValuePair<Kolegij, List<Student>> par in upisi)
                    if (par.Key.sifra == sifra)
                        return par.Value;
                throw new KeyNotFoundException("Ne postoji kolegij s tom šifrom.");
            }
        }
        public string this[Student student]
        {
            get
            {
                List<Kolegij> kolegiji = new List<Kolegij>();
                int suma_ects = 0;
                foreach (KeyValuePair<Kolegij, List<Student>> par in upisi)
                    if (par.Value.Contains(student))
                    {
                        kolegiji.Add(par.Key);
                        suma_ects += par.Key.ects;
                    }


            }
        }

        public override string ToString()
        {
            string ret = "";
            foreach (Kolegij k in upisi.Keys) 
                ret += "\t" + k.ToString() + "\n";
            return ret;
        }

        public Fakultet(string naziv)
        {
            this.naziv = naziv;
            upisi = new Dictionary<Kolegij, List<Student>>();
        }
    }
}
