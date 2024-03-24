using System;

class Program
{
    // İTERATİF KODU
    // Verilen bir dizi içindeki en büyük sayıyı bulan bir metod oluşturdum 

    static int EnBuyukSayi(int[] dizi)
    {
        int enBuyuk = dizi[0]; // İlk elemanı en büyük olarak kabul edelim 
                               // Döngü oluşturup  dizinin tüm elemanlarını kontrol ediyoruz. 
        for (int i = 1; i < dizi.Length; i++)
        {
            // Eğer dizinin mevcut elemanı, şu ana kadar bulunan en büyük sayıdan daha büyükse, 
            // en büyük sayıyı güncelliyoruz 
            if (dizi[i] > enBuyuk)
            {
                enBuyuk = dizi[i]; // Bu satır for döngüsü içinde olmalı
            }
        }
        return enBuyuk;
    }
    static void Main(string[] args)
    {
        // Örnek bir dizi oluşturuyoruz. 
        int[] dizi = { 5, 8, 3, 12, 6, 9 };
        // EnBuyukSayi metodunu çağırarak en büyük sayıyı buluyoruz. 
        int enBuyuk = EnBuyukSayi(dizi);
        // Bulunan en büyük sayıyı ekrana yazdırıyoruz. 
        Console.WriteLine("Dizideki en büyük sayı (iteratif): " + enBuyuk);
        Console.ReadLine();
    }
}
