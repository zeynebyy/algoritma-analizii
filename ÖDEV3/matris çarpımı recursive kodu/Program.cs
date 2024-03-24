using System;

class MatrisHeaplamaRecurisive
{
    static int[,] MatrixMultiplyRecursive(int[,] A, int[,] B, int n)
    {
        int[,] C = new int[n, n]; // Çarpım sonucu oluşacak matris

        // Baz durum: n = 1 ise, çarpım işlemi doğrudan gerçekleştirilir
        if (n == 1)
        {
            C[0, 0] = A[0, 0] * B[0, 0];
        }
        else
        {
            int[,] A11 = new int[n / 2, n / 2];
            int[,] A12 = new int[n / 2, n / 2];
            int[,] A21 = new int[n / 2, n / 2];
            int[,] A22 = new int[n / 2, n / 2];

            int[,] B11 = new int[n / 2, n / 2];
            int[,] B12 = new int[n / 2, n / 2];
            int[,] B21 = new int[n / 2, n / 2];
            int[,] B22 = new int[n / 2, n / 2];

            // A ve B matrislerini dört parçaya ayırma
            SplitMatrix(A, A11, 0, 0);
            SplitMatrix(A, A12, 0, n / 2);
            SplitMatrix(A, A21, n / 2, 0);
            SplitMatrix(A, A22, n / 2, n / 2);

            SplitMatrix(B, B11, 0, 0);
            SplitMatrix(B, B12, 0, n / 2);
            SplitMatrix(B, B21, n / 2, 0);
            SplitMatrix(B, B22, n / 2, n / 2);

            // Recursive olarak dört parçalı matrislerin çarpımı
            int[,] C11 = AddMatrix(MatrixMultiplyRecursive(A11, B11, n / 2), MatrixMultiplyRecursive(A12, B21, n / 2), n / 2);
            int[,] C12 = AddMatrix(MatrixMultiplyRecursive(A11, B12, n / 2), MatrixMultiplyRecursive(A12, B22, n / 2), n / 2);
            int[,] C21 = AddMatrix(MatrixMultiplyRecursive(A21, B11, n / 2), MatrixMultiplyRecursive(A22, B21, n / 2), n / 2);
            int[,] C22 = AddMatrix(MatrixMultiplyRecursive(A21, B12, n / 2), MatrixMultiplyRecursive(A22, B22, n / 2), n / 2);

            // C matrisini birleştirme
            CombineMatrix(C, C11, 0, 0);
            CombineMatrix(C, C12, 0, n / 2);
            CombineMatrix(C, C21, n / 2, 0);
            CombineMatrix(C, C22, n / 2, n / 2);
        }

        return C;
    }

    static void SplitMatrix(int[,] P, int[,] C, int iB, int jB)
    {
        for (int i1 = 0, i2 = iB; i1 < C.GetLength(0); i1++, i2++)
        {
            for (int j1 = 0, j2 = jB; j1 < C.GetLength(1); j1++, j2++)
            {
                C[i1, j1] = P[i2, j2];
            }
        }
    }

    static void CombineMatrix(int[,] C, int[,] P, int iB, int jB)
    {
        for (int i1 = 0, i2 = iB; i1 < P.GetLength(0); i1++, i2++)
        {
            for (int j1 = 0, j2 = jB; j1 < P.GetLength(1); j1++, j2++)
            {
                C[i2, j2] = P[i1, j1];
            }
        }
    }

    static int[,] AddMatrix(int[,] A, int[,] B, int n)
    {
        int[,] C = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                C[i, j] = A[i, j] + B[i, j];
            }
        }
        return C;
    }

    static void PrintMatrix(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        Console.WriteLine("Çarpım Sonucu Matris:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    static void Main()
    {
        int n = 4; // Örnek olarak 4x4 matrisler üzerinden işlem yapalım

        int[,] A = { {1, 2, 3, 4},
                     {5, 6, 7, 8},
                     {9, 10, 11, 12},
                     {13, 14, 15, 16} };

        int[,] B = { {17, 18, 19, 20},
                     {21, 22, 23, 24},
                     {25, 26, 27, 28},
                     {29, 30, 31, 32} };

        int[,] C = MatrixMultiplyRecursive(A, B, n);
        PrintMatrix(C);
        Console.ReadLine();
    }
}
