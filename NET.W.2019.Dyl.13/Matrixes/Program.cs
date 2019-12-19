

namespace Matrixes
{
    class Program
    {
        static void Main(string[] args)
        {
            DiagonalMatrix<int> matr1 = new DiagonalMatrix<int>(new int[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } });
            SymmetricalMatrix<int> matr2 = new SymmetricalMatrix<int>(new int[,] { { 1, 3, 0 }, { 3, 2, 6 }, { 0, 6, 5 } });

            SquareMatrix<int> res = matr1.Add(matr2);
            SquareMatrix<int> expectedRes = new SquareMatrix<int>(new int[,] { { 2, 3, 0 }, { 3, 3, 6 }, { 0, 6, 6 } });

            res.ToString();

            System.Console.ReadKey();
        }
    }
}
