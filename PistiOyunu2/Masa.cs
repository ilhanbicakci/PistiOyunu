using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PistiOyunu2
{
    internal class Masa
    {
        public Deste OyunDestesi;
        public Oyuncu[] Oyuncular {  get; set; }
        public List<Kart> Yer {  get; set; }
        private int enSonElAlanOyuncuIndex;

        public Masa(int oyuncu_sayisi)
        {
            OyunDestesi = new Deste();
            Oyuncular = new Oyuncu[oyuncu_sayisi];
            Yer = new List<Kart>();
            for (int i = 0; i < oyuncu_sayisi; i++)
            {
                Oyuncular[i] = new Oyuncu($"Oyuncu {i + 1}");
            }
            Yer = OyunDestesi.KartVer(4);
            
            OyunOyna();
        }



        public void Dagit()
        {
            for (int i = 0; i < Oyuncular.Length; i++)
            {
                Oyuncular[i].El = OyunDestesi.KartVer(4);
            }
        }



        public bool PistiMiOldu(Kart atilan)
        {
            if (Yer.Count == 1)
            {
                if (Yer[0].Deger == atilan.Deger)
                {
                    return true;
                }
            }
            return false;
        }



        public bool KuralUygula(Kart atilan)
        {
            if (Yer.Count > 0)
            {
                Kart ust = Yer[Yer.Count - 1];
                if (ust.Deger == atilan.Deger || atilan.Deger == "Vale")
                {
                    return true;
                }
            }
            return false;
        }



        public void ElOyna()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < Oyuncular.Length; j++)
                {
                    Kart atilan = Oyuncular[j].KartAt();
                    if (KuralUygula(atilan))
                    {
                        if (PistiMiOldu(atilan))
                        {
                            Oyuncular[j].PistiSayisi++;
                        }
                        Yer.Add(atilan);
                        Oyuncular[j].Topla(Yer);
                        Yer.Clear();
                        enSonElAlanOyuncuIndex = j;
                    }
                    else
                    {
                        Yer.Add(atilan);
                    }
                }
            }
        }



        public void OyunOyna()
        {
            while (OyunDestesi.Kartlar.Count > 0)
            {
                Dagit();
                ElOyna();
            }
            Oyuncular[enSonElAlanOyuncuIndex].Topla(Yer);
            Yer.Clear();
            int enCokKartiOlanOyuncuIndex = 0;
            for (int i = 0; i < Oyuncular.Length; i++)
            {
                if (Oyuncular[enCokKartiOlanOyuncuIndex].ToplananSayisi < Oyuncular[i].ToplananSayisi)
                {
                    enCokKartiOlanOyuncuIndex = 1;
                }
            }
            Oyuncular[enCokKartiOlanOyuncuIndex].EnCokKart = true;
        }

       

        

        public override string ToString()
        {
            return $"{OyunDestesi}\n\n" +
                $"Yer ({Yer.Count}): {string.Join(", ", Yer)}\n\n" +
                $"Oyuncular:\n{string.Join("\n\n", Oyuncular.ToList())}";
        }
    }
}
