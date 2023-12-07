using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Upisi
{
    class Student
    {
        public readonly string jmbag, ime, prezime;

        public override bool Equals(object? obj)
        {
            return obj is Student && Equals(obj);
        }
        public bool Equals(Student obj)
        {
            return jmbag == obj.jmbag;
        }
        public override int GetHashCode()
        {
            return jmbag.GetHashCode();
        }
        public override string ToString()
        {
            return $"{jmbag} ({prezime}, {ime})";
        }

        public static List<Student> operator +(List<Student> orig, Student novi)
        {
            if (orig.Contains(novi))
                throw new ArgumentException("Taj je student već upisan na kolegij.");
            orig.Add(novi);
            return orig;
        }
        public static List<Student> operator -(List<Student> orig, Student novi)
        {
            orig.Remove(novi);
            return orig;
        }

        public Student(string jmbag, string ime, string prezime)
        {
            this.jmbag = jmbag;
            this.ime = ime;
            this.prezime = prezime;
        }
        public Student()
        {
            bool ispravan = false;
            string unos = "";
            while (!ispravan)
            {
                Console.WriteLine("Unesite podatke o studentu u formatu JMBAG, imena, prezimena");
                unos = Console.ReadLine();
                Regex reg_unos = new Regex(@"^\d{10},\s[A-Z][a-z]+(\s[A-Z][a-z]+)*,\s[A-Z][a-z]+(\s[A-Z][a-z]+)*$");
                ispravan = reg_unos.IsMatch(unos);
            }
            string[] parametri = unos.Split(", ");
            jmbag = parametri[0];
            ime = parametri[1];
            prezime = parametri[2];
        }
    }
}
