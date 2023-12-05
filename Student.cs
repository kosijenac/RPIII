using System;
using System.Collections.Generic;
using System.Text;

namespace Upisi
{
    class Student
    {
        public readonly string jmbag, ime, prezime;

        public override bool Equals(object obj)
        {
            return obj is Student && Equals(obj);
        }
        public bool Equals(Student obj)
        {
            return jmbag == obj.jmbag;
        }

        public Student(string jmbag, string ime, string prezime)
        {
            this.jmbag = jmbag;
            this.ime = ime;
            this.prezime = prezime;
        }
        public Student()
        {
            Console.WriteLine("Unesite podatke o studentu u formatu [JMBAG, imena, prezimena]")
        }
    }
}
