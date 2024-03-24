using System;

class MatrisHesaplama
{
    static void Main()
    {
        int n = 3; // Örnek olarak 3x3 matrisler üzerinden işlem yapalım

        // İlk matris A
        int[,] A = { {1, 2, 3},
                     {5, 9, 2},
                     {7, 4, 6} };

        // İkinci matris B
        int[,] B = { {9, 3, 7},
                     {6, 1, 2},
                     {4, 2, 5} };

        // Çarpım sonucu oluşacak matris C matrisi 
        int[,] C = new int[n, n];
        
        // Çarpım işlemi
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                C[i, j] = 0;
                for (int k = 0; k < n; k++)
                {
                    C[i, j] += A[i, k] * B[k, j];
                }
            }
        }

        // Çarpım sonucunu ekrana yazdır
        Console.WriteLine("Çarpım Sonucu Matris:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(C[i, j] + "\t");
            }
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
