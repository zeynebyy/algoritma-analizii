using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Faktöriyelini bulmak istediğiniz sayıyı girin:");
        int sayi = Convert.ToInt32(Console.ReadLine());

        int faktoriyel = FaktoriyelHesapla(sayi);

        Console.WriteLine($"{sayi} sayısının faktöriyeli: {faktoriyel}");
        Console.ReadLine();
    }

    static int FaktoriyelHesapla(int n)
    {
        // Recursive metot, n'nin 0 veya 1 olduğu durumları ele alır.
        // Eğer n 0 veya 1 ise, faktöriyel değeri 1 olarak döner.
        if (n == 0 || n == 1)
            return 1;
        // Eğer n 2 veya daha büyük ise, faktöriyel değeri n * FaktoriyelHesapla(n - 1) olarak hesaplanır.
        // Bu durum recursive olarak n'yi 1 azaltarak devam eder, n = 1 olduğunda base case'e ulaşılır ve recursive işlem sonlanır.
        else
            return n * FaktoriyelHesapla(n - 1);
    }
}


