using System;

class Program
{
    // Dizideki en büyük sayıyı özyinelemeli (recursive) olarak bulan bir metod tanımladık. 
    static int EnBuyukSayiyiBul(int[] dizi, int n)
    {
        // Dizinin boyutu 1 ise, dizinin tek elemanı en büyük sayıdır, dolayısıyla bu elemanı döndürürüz. 
        if (n == 1)
            return dizi[0];

        // "Math.Max" fonksiyonu, iki sayı arasından büyük olanı döndüren matematiksel bir fonksiyondur  
        // Burada, dizinin son elemanı ile (dizi[n - 1]) bir önceki en büyük sayıyı karşılaştırıyoruz 
        // en büyük olanı belirleriz ve recursive olarak bu işlemi devam ettiririz. 
        return Math.Max(dizi[n - 1], EnBuyukSayiyiBul(dizi, n - 1));
    }

    static void Main(string[] args)
    {
        // Örnek bir dizi oluşturulur. 
        int[] dizi = { 5, 8, 3, 12, 6, 9 };

        // EnBuyukSayiyiBul metodu çağırılarak en büyük sayı bulunur. 
        // Metoda, dizi ve dizinin uzunluğu (n) parametre olarak verilir. 
        int enBuyuk = EnBuyukSayiyiBul(dizi, dizi.Length);

        // Bulunan en büyük sayı konsola yazdırılır. 
        Console.WriteLine("Dizideki en büyük sayı (recursive): " + enBuyuk);

        // Kullanıcının konsolu kapatmadan önce bir tuşa basmasını beklemek için kullanılır. 
        Console.ReadLine();
    }
}
