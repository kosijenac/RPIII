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
            get
            {
                HashSet<Student> ukupno = new();
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
            set { }
        }
        public string this[Student student]
        {
            get
            {
                List<Kolegij> kolegiji = new();
                foreach (KeyValuePair<Kolegij, List<Student>> par in upisi)
                    if (par.Value.Contains(student))
                        kolegiji.Add(par.Key);
                List<string> nazivi = new(kolegiji.Select(kol => kol.naziv));
                nazivi.Sort();
                string ret = "Ukupno ECTS-a: ";
                ret += kolegiji.Aggregate(0, (acc, kol) => acc + kol.ects);
                ret += "\nUpisani kolegiji:\n" + string.Join('\n', nazivi);
                return ret;
            }
        }

        public override string ToString()
        {
            string ret = "";
            foreach (Kolegij k in upisi.Keys)
                ret += "\t" + k.ToString() + "\n";
            return ret;
        }

        public static Fakultet operator +(Fakultet orig, Kolegij novi)
        {
            if (orig.upisi.ContainsKey(novi))
                throw new ArgumentException("Kolegij s tom šifrom već postoji.");
            orig.upisi[novi] = new();
            return orig;
        }

        public Fakultet(string naziv)
        {
            this.naziv = naziv;
            upisi = new();
        }
    }
}
