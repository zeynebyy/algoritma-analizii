using System;
using System.Collections.Generic;

// Kenar sınıfı, grafikteki kenarları temsil eder ve IComparable arayüzü ile ağırlıklarına göre sıralanabilir.
class Kenar : IComparable<Kenar>
{
    public int Kaynak { get; }  // Kenarın başladığı düğüm
    public int Hedef { get; }   // Kenarın bittiği düğüm
    public int Agirlik { get; } // Kenarın ağırlığı

    public Kenar(int kaynak, int hedef, int agirlik)
    {
        Kaynak = kaynak;
        Hedef = hedef;
        Agirlik = agirlik;
    }

    // Kenarları ağırlıklarına göre karşılaştırmak için CompareTo metodunu uygular.
    public int CompareTo(Kenar diger)
    {
        return Agirlik.CompareTo(diger.Agirlik);
    }
}

// Grafik sınıfı, düğümleri ve kenarları tutar.
class Grafik
{
    public int DugumSayisi { get; }       // Grafikteki düğüm sayısı
    public List<Kenar> Kenarlar { get; }  // Grafikteki kenarların listesi

    public Grafik(int dugumSayisi)
    {
        DugumSayisi = dugumSayisi;
        Kenarlar = new List<Kenar>();
    }

    // Grafiğe kenar eklemek için metot
    public void KenarEkle(int kaynak, int hedef, int agirlik)
    {
        Kenarlar.Add(new Kenar(kaynak, hedef, agirlik));
    }

    // Kruskal algoritmasını kullanarak Minimum Spanning Tree (MST) oluşturma
    public void KruskalMST()
    {
        // Kenarları ağırlıklarına göre sırala
        Kenarlar.Sort();

        // Union-Find veri yapısını başlat
        int[] ebeveyn = new int[DugumSayisi];
        for (int i = 0; i < DugumSayisi; i++)
            ebeveyn[i] = i;

        // Bul (Find) fonksiyonu, düğümün kök ebeveynini bulur.
        int Bul(int i)
        {
            if (ebeveyn[i] == i)
                return i;
            return ebeveyn[i] = Bul(ebeveyn[i]);
        }

        // Birleşme (Union) fonksiyonu, iki kümenin kök ebeveynlerini birleştirir.
        void Birlesme(int x, int y)
        {
            int xKok = Bul(x);
            int yKok = Bul(y);
            ebeveyn[xKok] = yKok;
        }

        List<Kenar> mst = new List<Kenar>();  // MST'yi tutacak liste
        foreach (Kenar kenar in Kenarlar)
        {
            int x = Bul(kenar.Kaynak);
            int y = Bul(kenar.Hedef);

            // Döngü oluşmuyorsa kenarı ekle
            if (x != y)
            {
                mst.Add(kenar);
                Birlesme(x, y);
            }
        }

        // MST'yi yazdır
        Console.WriteLine("Kaynak\tHedef\tAğırlık");
        foreach (Kenar kenar in mst)
        {
            Console.WriteLine($"{kenar.Kaynak}\t{kenar.Hedef}\t{kenar.Agirlik}");
        }
    }
}

class Program
{
    static void Main()
    {
        Grafik g = new Grafik(6); // 6 düğümlü bir grafik oluştur
        g.KenarEkle(0, 1, 4);     // Kenar ekle: Kaynak = 0, Hedef = 1, Ağırlık = 4
        g.KenarEkle(0, 2, 4);
        g.KenarEkle(1, 2, 2);
        g.KenarEkle(1, 0, 4);
        g.KenarEkle(2, 0, 4);
        g.KenarEkle(2, 1, 2);
        g.KenarEkle(2, 3, 3);
        g.KenarEkle(2, 5, 2);
        g.KenarEkle(2, 4, 4);
        g.KenarEkle(3, 2, 3);
        g.KenarEkle(3, 4, 3);
        g.KenarEkle(4, 2, 4);
        g.KenarEkle(4, 3, 3);
        g.KenarEkle(5, 2, 2);
        g.KenarEkle(5, 4, 3);

        g.KruskalMST(); // Kruskal algoritmasını çalıştır ve MST'yi bul

        Console.ReadKey(); 
    }
}
