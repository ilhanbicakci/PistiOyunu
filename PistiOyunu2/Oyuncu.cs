using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PistiOyunu2
{
    internal class Oyuncu
    {
        public string Ad {  get; set; }
        public List<Kart> El {  private get; set; }
        public int PistiSayisi { get; set; }
        public int Puan
        {
            get
            {
                int toplam = toplanan.Sum(Kart => Kart.Puan);
                if (EnCokKart)
                {
                    toplam += 3;
                }
                return toplam + PistiSayisi * 10;
            }
        }

        private List<Kart> toplanan;
        public int ToplananSayisi { get { return toplanan.Count; } }
        public bool EnCokKart { get; set;}
        private Random random = new Random();



        public Oyuncu(string ad)
        {
            Ad = ad;
            El = new List<Kart>();
            toplanan = new List<Kart>();
            PistiSayisi = 0;
            EnCokKart = false;
        }

        public Kart KartAt()
        {
            int i = random.Next(El.Count);
            Kart atilacak = El[i];
            El.RemoveAt(i);
            return atilacak;
        }

        public void Topla(List<Kart> yer)
        {
            toplanan.AddRange(yer);
        }

        public override string ToString()
        {
            return $"{Ad} ({Puan}p):\n" +
                   $"Pişti Sayısı: {PistiSayisi}\n" +
                   $"En Çok Kart: {EnCokKart}\n" +
                   $"El ({El.Count}): {string.Join(", ", El)}\n" +
                   $"Toplanan ({toplanan.Count}): {string.Join(", ", toplanan)}";
        }
    }
}
