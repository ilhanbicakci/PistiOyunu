using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PistiOyunu2
{
    internal class Kart
    {
        private string yuz;

        public string Yuz { get { return yuz; } }
        private string deger;
        public string Deger { get {  return deger; } }

        public int Puan
        {
            get
            {
                if (deger == "Vale" || deger == "As")
                {
                    return 1;
                }
                else if (deger == "2" && yuz == "Sinek")
                {
                    return 2;
                }
                else if (deger == "10" && yuz == "Karo")
                {
                    return 3;
                }
                else
                {
                    return 0;
                }
            }
        }

        public Kart(string yuz, string deger)
        {
            this.yuz = yuz;
            this.deger = deger;
        }

        public override string ToString()
        {
            return $"| {yuz} {deger} ({Puan}) |";
        }
    }
}
