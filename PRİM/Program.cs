using System;

class PrimAlgoritmasi
{
    // Grafik komşuluk matrisi olarak temsil ediliyor
    private static int DUGUM_SAYISI = 5;

    // MST'ye henüz dahil edilmemiş düğümler kümesinden minimum anahtar değerine sahip düğümü bulmak için yardımcı fonksiyon
    private static int MinimumAnahtar(int[] anahtar, bool[] mstKumesi)
    {
        int min = int.MaxValue, minIndeks = -1;

        for (int v = 0; v < DUGUM_SAYISI; v++)
            if (mstKumesi[v] == false && anahtar[v] < min)
            {
                min = anahtar[v];
                minIndeks = v;
            }

        return minIndeks;
    }

    // Oluşturulan MST'yi parent[] dizisinde saklar ve yazdırır
    private static void MSTYazdir(int[] ebeveyn, int[,] grafik)
    {
        Console.WriteLine("Kenar \tAğırlık");
        for (int i = 1; i < DUGUM_SAYISI; i++)
            Console.WriteLine($"{ebeveyn[i]} - {i} \t{grafik[i, ebeveyn[i]]}");
    }

    // Komşuluk matrisi kullanarak temsil edilen bir grafik için MST'yi oluşturur ve yazdırır
    public static void PrimMST(int[,] grafik)
    {
        int[] ebeveyn = new int[DUGUM_SAYISI];  // Oluşturulan MST'yi saklamak için dizi
        int[] anahtar = new int[DUGUM_SAYISI];  // Kesimde minimum ağırlıklı kenarı seçmek için anahtar değerleri
        bool[] mstKumesi = new bool[DUGUM_SAYISI]; // MST'ye henüz dahil edilmemiş düğümleri temsil eder

        // Tüm anahtarları sonsuz olarak başlat
        for (int i = 0; i < DUGUM_SAYISI; i++)
        {
            anahtar[i] = int.MaxValue;
            mstKumesi[i] = false;
        }

        // İlk düğümü her zaman MST'ye dahil et
        anahtar[0] = 0;     // Bu düğümün ilk düğüm olarak seçilmesi için anahtar 0 yapılır
        ebeveyn[0] = -1; // İlk düğüm her zaman MST'nin köküdür

        // MST, DUGUM_SAYISI düğüm içerecek
        for (int sayac = 0; sayac < DUGUM_SAYISI - 1; sayac++)
        {
            // MST'ye henüz dahil edilmemiş düğümler kümesinden minimum anahtar değerine sahip düğümü seç
            int u = MinimumAnahtar(anahtar, mstKumesi);

            // Seçilen düğümü MST kümesine ekle
            mstKumesi[u] = true;

            // Seçilen düğümün komşularının anahtar değerini ve ebeveyn indeksini güncelle
            for (int v = 0; v < DUGUM_SAYISI; v++)

                // grafik[u, v] sadece u ve v arasında kenar varsa sıfırdan farklıdır
                // mstKumesi[v] MST'ye henüz dahil edilmemiş düğümler için false'dur
                // grafik[u, v] anahtar[v]'den küçükse anahtar'ı güncelle
                if (grafik[u, v] != 0 && mstKumesi[v] == false && grafik[u, v] < anahtar[v])
                {
                    ebeveyn[v] = u;
                    anahtar[v] = grafik[u, v];
                }
        }

        // Oluşturulan MST'yi yazdır
        MSTYazdir(ebeveyn, grafik);
    }

    // Ana fonksiyon
    public static void Main()
    {
        
        int[,] grafik = new int[,] {
            { 0, 2, 0, 6, 0 },
            { 2, 0, 3, 8, 5 },
            { 0, 3, 0, 0, 7 },
            { 6, 8, 0, 0, 9 },
            { 0, 5, 7, 9, 0 }
        };

        // Çözümü yazdır
        PrimMST(grafik);
    }
}

/* oluşturulan grafik
              2    3
          (0)--(1)--(2)
          |   / \   |
         6| 8/   \5 |7
          | /     \ |
          (3)-------(4)
               9          */
