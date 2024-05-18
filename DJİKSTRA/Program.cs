using System;
using System.Collections.Generic;

public class PriorityQueue<T> //sınıfı, öncelik sırasına göre eleman ekleyip çıkaran bir veri yapısıdır.
{
    private List<(T element, int priority)> elements = new List<(T, int)>();

    // Kuyruğun eleman sayısını döndürür
    public int Count => elements.Count;

    // Eleman ekleme fonksiyonu
    public void Enqueue(T item, int priority)
    {
        // Yeni elemanı listeye ekle
        elements.Add((item, priority));
        // Listenin elemanlarını önceliklerine göre sırala
        elements.Sort((x, y) => x.priority.CompareTo(y.priority));
    }

    // Eleman çıkarma fonksiyonu
    public T Dequeue()
    {
        // Listenin ilk elemanını al (önceliği en yüksek olan)
        var bestItem = elements[0].element;
        // Bu elemanı listeden çıkar
        elements.RemoveAt(0);
        return bestItem;
    }
}

class Grafik
{
    public int DugumSayisi { get; }
    public List<(int, int)>[] KomsuListesi { get; }

    // Grafiğin yapıcısı (constructor)
    public Grafik(int dugumSayisi)
    {
        DugumSayisi = dugumSayisi;
        KomsuListesi = new List<(int, int)>[dugumSayisi];
        for (int i = 0; i < dugumSayisi; i++)
            KomsuListesi[i] = new List<(int, int)>();
    }

    // Kenar ekleme fonksiyonu
    public void KenarEkle(int kaynak, int hedef, int agirlik)
    {
        // Komşu listesinin her iki tarafına da kenar ekle
        KomsuListesi[kaynak].Add((hedef, agirlik));
        KomsuListesi[hedef].Add((kaynak, agirlik)); // İki yönlü kenar ekliyoruz
    }

    // Dijkstra algoritması
    public void Djikstra(int kaynak)
    {
        int[] mesafeler = new int[DugumSayisi];
        bool[] islenmisDugumler = new bool[DugumSayisi];

        // Mesafeleri ve işlenmiş düğümleri başlat
        for (int i = 0; i < DugumSayisi; i++)
        {
            mesafeler[i] = int.MaxValue;
            islenmisDugumler[i] = false;
        }

        mesafeler[kaynak] = 0;
        PriorityQueue<(int, int)> oncelikKuyrugu = new PriorityQueue<(int, int)>();

        // Başlangıç düğümünü öncelik kuyruğuna ekle
        oncelikKuyrugu.Enqueue((kaynak, 0), 0);

        while (oncelikKuyrugu.Count > 0)
        {
            // Öncelik kuyruğundan en düşük mesafeli düğümü al
            var (u, dist) = oncelikKuyrugu.Dequeue();
            if (islenmisDugumler[u])
                continue;

            islenmisDugumler[u] = true;

            // Komşuları dolaş
            foreach (var (komsu, agirlik) in KomsuListesi[u])
            {
                // Komşunun yeni mesafesini hesapla ve gerekirse güncelle
                if (!islenmisDugumler[komsu] && mesafeler[u] != int.MaxValue && mesafeler[u] + agirlik < mesafeler[komsu])
                {
                    mesafeler[komsu] = mesafeler[u] + agirlik;
                    oncelikKuyrugu.Enqueue((komsu, mesafeler[komsu]), mesafeler[komsu]);
                }
            }
        }

        // Mesafeleri ekrana yazdır
        Yazdir(mesafeler);
    }

    private void Yazdir(int[] mesafeler)
    {
        Console.WriteLine("Düğüm \t Kaynaktan Uzaklık");
        for (int i = 0; i < DugumSayisi; i++)
            Console.WriteLine($"{i} \t {mesafeler[i]}");
    }
}

class Program
{
    static void Main()
    {
        // Bir grafik oluştur
        Grafik g = new Grafik(6);
        g.KenarEkle(0, 1, 7);
        g.KenarEkle(0, 2, 9);
        g.KenarEkle(0, 5, 14);
        g.KenarEkle(1, 2, 10);
        g.KenarEkle(1, 3, 15);
        g.KenarEkle(2, 3, 11);
        g.KenarEkle(2, 5, 2);
        g.KenarEkle(3, 4, 6);
        g.KenarEkle(4, 5, 9);

        // Dijkstra algoritmasını çalıştır
        g.Djikstra(0);

        // Ekranı beklet
        Console.ReadKey();
    }
}

