using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PistiOyunu2
{
    internal class Deste
    {
        public List<Kart> Kartlar { get; private set; }

        public Deste()
        {
            Kartlar = new List<Kart>();
            string[] yuzler = { "Sinek", "Karo", "Maça", "Kupa" };
            string[] degerler = { "As", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Vale", "Kız", "Papaz" };

            for ( int i = 0; i < yuzler.Length; i++ )
            {
                for( int j = 0; j < degerler.Length; j++ )
                {
                    Kartlar.Add(new Kart(yuzler[i], degerler[j]));
                }
            }

            Karistir();
        }

        private void Karistir()
        {
            Random random = new Random();
            for ( int i = 0; i < 100 ; i++ )
            {
                int ilk_index = random.Next(0, 26);
                int ikinci_index = random.Next(26, 52);

                (Kartlar[ilk_index], Kartlar[ikinci_index]) = (Kartlar[ikinci_index], Kartlar[ilk_index]);
            }
        }

        public List<Kart> KartVer(int kart_sayisi)
        {
            List<Kart> verilenler = Kartlar.Take(kart_sayisi).ToList();
            Kartlar.RemoveRange(0, kart_sayisi);
            return verilenler;
        }

        public override string ToString()
        {
            return $"Deste ({Kartlar.Count}): {string.Join(", ", Kartlar)}";
        }
    }
}
