using System;
using System.Collections.Generic;
using System.Text;

namespace Kursova
{
    public class CarPrice : Cars
    {
        private int adres;

        public int Adres
        {
            get { return adres; }
            set { adres = value; }
        }
        private int grad;

        public int Grad
        {
            get { return grad; }
            set { grad = value; }
        }
        private int telefon;

        public int Telefon
        {
            get { return telefon; }
            set { telefon = value; }
        }
    }
}
