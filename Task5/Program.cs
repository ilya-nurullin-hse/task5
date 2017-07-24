using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class Program
    {
        private static float[,] _matrix;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Введите значение порядка матрицы: ");
                int size = int.Parse(Console.ReadLine());

                _matrix = new float[size, size];

                generateRandomMartix();

                printMatrix();

                Console.WriteLine(maxElement());
            }
        }

        static float maxElement()
        {
            int size = _matrix.GetLength(1);
            float max = 0;

            for (int i = 0; i < Math.Ceiling((decimal)size / 2); i++)
            {
                for (int j = i; j < size - i ; j++)
                {
                    max = Math.Max(_matrix[i, j], max);
                }
            }

            return max;
        }

        static void generateRandomMartix()
        {
            int size = _matrix.GetLength(1);
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    _matrix[i, j] = (float) rand.NextDouble();
                }
            }
        }

        static void printMatrix()
        {
            int size = _matrix.GetLength(1);
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write("{0:0.0000000 }",_matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
