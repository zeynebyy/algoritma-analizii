using System;

class Program
{
    static void Main()
    {
        int A = 2135;
        int B = 4014;

        int çarpım = Multiply(A, B);

        Console.WriteLine("A * B = " + çarpım);
    }

    static int Multiply(int num1, int num2)   // İki sayının çarpımını hesaplayan fonksiyon
    {
        int sonuç = 0;

        while (num2 != 0)
        {
            if ((num2 & 1) != 0) // Eğer num2'nin en sağdaki biti 1 ise
            {
                sonuç = ekle(sonuç, num1); // Sonucu günceller
            }
            num1 <<= 1; // num1'i bir sola kaydır
            num2 >>= 1; // num2'yi bir sağa kaydır
        }

        return sonuç;
    }

    static int ekle(int a, int b)
    {
        while (b != 0)
        {
            int c = a & b; // Taşıyıcıyı hesapla
            a = a ^ b; // Toplamı bul
            b = c << 1; // Taşıyıcıyı sonraki basamağa taşı
            Console.ReadLine();
        }
        return a;
    }
}
