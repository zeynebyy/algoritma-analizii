using System;

class Program
{
    // İteratif bir fonksiyon ile ondalık sayıyı ikili sayıya dönüştüren metot 
    static string DecimalToBinary(int decimalNumber)
    {
        // Özel durum: Eğer ondalık sayı 0 ise, ikili sayı da 0'dır. 
        if (decimalNumber == 0)
            return "0";

        string binary = ""; // Dönüştürülecek ikili sayıyı saklayacak değişken 

        // Ondalık sayı sıfır olana kadar döngü çalışır işlem devam eder 
        while (decimalNumber > 0)
        {
            // Ondalık sayının 2'ye bölümünden kalan alınır 
            int remainder = decimalNumber % 2;

            // Kalan, ikili sayının başına eklenir 
            binary = remainder + binary;

            // Ondalık sayı, 2'ye bölünür (tam bölme yapılır) 
            decimalNumber /= 2;
        }

        return binary; // İkili sayı döndürülür 
    }

    static void Main(string[] args)
    {
        int decimalNumber = 25; // Örnek bir ondalık sayı 
        // Ondalık sayıyı ikili sayıya dönüştürme işlemi yapılır 
        string binaryNumber = DecimalToBinary(decimalNumber);
        // Sonuçları ekrana yazdır 
        Console.WriteLine("Ondalık sayı " + decimalNumber + " ikili sayıya dönüştürüldü( iteratif): " + binaryNumber);
        Console.ReadLine();
    }
}
