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
            Console.WriteLine("Дана действительная квадратная матрица порядка n. Найти наибольшее из значений элементов, " +
                              "расположенных в заштрихованной части матрицы:");
            while (true)
            {
                Console.Write("Введите значение порядка матрицы: ");
                try
                {
                    int size = int.Parse(Console.ReadLine());
                    if (size < 1 )
                        throw new FormatException();

                    _matrix = new float[size, size];

                    fillMatrix(size);

                    printMatrix();

                    Console.WriteLine("Максимальный элемент в области = {0}", maxElement());
                }
                catch (FormatException)
                {
                    Console.Write("Порядок матрицы должен быть натуральным числом. Попробуйте ещё раз.");
                }
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

        static void fillMatrix(int size)
        {
            string answer = "";
            while (true)
            {
                Console.WriteLine("1. Сгенерировать матрицу случайно");
                Console.WriteLine("2. Ввести матрицу вручную");
                Console.Write("Выберите вариант 1 или 2: ");
                answer = Console.ReadLine();
                if (answer != "1" && answer != "2")
                {
                    Console.WriteLine("Ожидалось 1 или 2");
                }
                else
                    break;
            }
            if (answer == "1")
                generateRandomMartix();
            else
            {
                Console.WriteLine("Вводите матрицу построчно. Элементы каждой строки разделяются пробелом. Тип элементов: float");
                for (int i = 0; i < size; i++)
                {
                    Console.Write("Введите через пробел элементы строки {0}: ", i + 1);
                    try
                    {
                        var elems = Console.ReadLine().Split().Select(float.Parse).ToArray();

                        if (elems.Length != size)
                        {
                            Console.WriteLine("Количество элементов не равно порядку матрицы. Порядок матрицы = {0}, " +
                                              "количетсов введенных элементов = {1}. Введите эту строчку ещё раз", size, elems.Length);
                            i--;
                            continue;
                        }
                        for (int j = 0; j < size; j++)
                        {
                            _matrix[i, j] = elems[j];
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Тип элементов должен быть float. Введите эту строчку ещё раз.");
                        i--;
                        continue;
                    }
                }
            }
        }
    }
}
