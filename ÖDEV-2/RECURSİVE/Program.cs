using System;

class Program
{
    // Rekürsif bir fonksiyon ile ondalık sayıyı ikili sayıya dönüştüren metot 
    static string DecimalToBinaryRecursive(int decimalNumber)
    {
        // Özel durum: Eğer ondalık sayı 0 ise, ikili sayı da 0'dır. 
        if (decimalNumber == 0)
            return "0";
        else
            // Ondalık sayının ikili dönüşümü, ondalık sayının yarısı ile bu fonksiyonun çağrılması ve son basamağın 
            // eklenmesiyle elde edilir 
            return DecimalToBinaryRecursive(decimalNumber / 2) + (decimalNumber % 2);
    }

    static void Main(string[] args)
    {
        int decimalNumber = 25; // Örnek bir ondalık sayı 
        // Ondalık sayıyı ikili sayıya dönüştürme işlemi yapılır 
        string binaryNumber = DecimalToBinaryRecursive(decimalNumber);
        // Sonuçları ekrana yazdır 
        Console.WriteLine("Ondalık sayı " + decimalNumber + " ikili sayıya dönüştürüldü: " + binaryNumber);

        Console.ReadLine();
    }
}
