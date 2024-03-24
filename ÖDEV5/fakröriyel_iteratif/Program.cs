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
        int faktoriyel = 1;
        // 1'den n'e kadar olan tüm sayıları çarpıyoruz
        for (int i = 1; i <= n; i++)
        {
            faktoriyel *= i;
        }
        return faktoriyel;
        
    }
}
