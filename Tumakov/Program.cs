using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.NetworkInformation;
using static System.Net.Mime.MediaTypeNames;
namespace Tumakov { 

    static class Matrix
    {
        //Метод для вычисления количества строк матриц 
        public static int RowsCount(this int[,] matrix)
        {
            return matrix.GetUpperBound(0) + 1;
        }
        // Метод для вычисления количества столбцов матрицы
        public static int ColumnsCount(this int[,] matrix)
        {
            return matrix.GetUpperBound(1) + 1;
        }
    }
    internal class Program
    {
        // Метод для срдених температур 
        static Dictionary<string, int[]> CalculateTemperatures2(int[,] temperatures)
        {
            Dictionary<string, int[]> srednieznacheniya = new Dictionary<string, int[]>();
            string[] months = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
            for (int i = 0; i < 12; i++)
            {
                int[] daytemperatures = new int[30];
                int sum = 0;
                for (int j = 0; j < 30; j++)
                {
                    daytemperatures[j] = temperatures[i, j];
                    sum += temperatures[i, j];
                }

                int sredneeznachenie = sum / 30; // Вычисление средней температуры для каждого месяца
                srednieznacheniya.Add(months[i], daytemperatures);
            }

            return srednieznacheniya;
        }


        //Метод для умножения матриц с помощью коллекции 
        static LinkedList<LinkedList<int>> MultiplyMatrix(int[,] matrix1, int[,] matrix2)
        {
            LinkedList<LinkedList<int>> resultMatrix = new LinkedList<LinkedList<int>>();
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                LinkedList<int> row = new LinkedList<int>();
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    int sum = 0;
                    for (int k = 0; k < matrix1.GetLength(1); k++)
                    {
                        sum += matrix1[i, k] * matrix2[k, j];
                    }
                    row.AddLast(sum);
                }
                resultMatrix.AddLast(row);
            }

            return resultMatrix;
        }

        static void PrintResultMatrix(LinkedList<LinkedList<int>> resultMatrix)
        {
            foreach (var row in resultMatrix)
            {
                foreach (var element in row)
                {
                    Console.Write(element + " ");
                }
                Console.WriteLine();
            }
        }
        //Метод для вычисления гласных и согласных с помощью коллекции 
        static void Calculate2(List<char> text, out int countvowels, out int countconsonants)
        {

            countvowels = 0;
            countconsonants = 0;
            string rvowels = "aAeEёЁиИоОуУыЫэЭюЮяЯ";
            string rconsonants = "йЙцЦкКнНгГшШщЩзЗхХъЪфФвВпПрРлЛдДжЖчЧсСмМтТьЬбБ";
            List<char> vowels = new List<char>(); // для хранения гласных
            List<char> consonants = new List<char>(); // для хранения согласных
            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    if (rvowels.Contains(c)) // Добавление гласных букв
                    {
                        vowels.Add(c);
                        countvowels++;

                    }
                    else if (rconsonants.Contains(c))
                    {
                        consonants.Add(c);
                        countconsonants++;
                    }
                }
            }
        }

            //Метод для вычисления средних температур 
            static int[] CalculateTemperatures(int[,] temperatures)
        {
            int[] sredneeznachenie = new int[12];
            for (int i = 0; i <12; i++)
            {
                int sum = 0;
                for (int j = 0; j <30; j++)
                {
                    sum += temperatures[i,j];
                }
                sredneeznachenie[i] = sum / 30; //Вычисление средней температуры для месяца
            }
            return sredneeznachenie;
        }
        // Метод для печати матрицы
        static void PrintMatrix(int[,] matrix)
        {
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j].ToString().PadLeft(4));
                }
                Console.WriteLine();
            }
        }
        // Метод для получения матриц с консоли 
        static int[,] GetMatrix(string name)
        {
            Console.Write("Количество строк матрицы {0}:    ", name);
            var n = int.Parse(Console.ReadLine());
            Console.Write("Количество столбцов матрицы {0}: ", name);
            var m = int.Parse(Console.ReadLine());

            var matrix = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("{0}[{1},{2}] = ", name, i, j);
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }

            return matrix;
        }
        // Метод для умножения матриц
        static int[,] CalculateMatrix(int[,] matrixA, int[,] matrixB)
        {
            if (matrixA.ColumnsCount() != matrixB.RowsCount())
            {
                throw new Exception("Умножение не возможно!");
            }
            var matrixC = new int[matrixA.RowsCount(), matrixB.ColumnsCount()];
            for (int i = 0; i < matrixA.RowsCount(); i++)
            {
                for (int j = 0; j < matrixB.ColumnsCount(); j++)
                {
                    matrixC[i, j] = 0;
                    for (int k = 0; k < matrixA.ColumnsCount(); k++)
                    {
                        matrixC[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }

            return matrixC;
        }
        static void Task1()
        {
            Console.WriteLine("Упражнение 6.1");
            string filename = "Text.txt";
            char[] letters = File.ReadAllText(filename).ToCharArray();
            int vowels, consonants;
            Calculate(letters, out vowels, out consonants);
            Console.WriteLine($"Число гласных:{vowels}");
            Console.WriteLine($"Число согласных:{consonants}");
        }
        static void Task2()
        {
            Console.WriteLine("Упражнение 6.2");
            Console.WriteLine("Программа для умножения матриц");
            var a = GetMatrix("A");
            var b = GetMatrix("B");
            Console.WriteLine("Матрица A:");
            PrintMatrix(a);
            Console.WriteLine("Матрица B:");
            PrintMatrix(b);
            var result = CalculateMatrix(a, b);
            Console.WriteLine("Произведение матриц:");
            PrintMatrix(result);
            Console.ReadLine();
        }
        static void Task3()
        {
            Console.WriteLine("Упражнение 6.3");
            int[,] temperatures = new int[12, 30];
            Random random = new Random();
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    temperatures[i, j] = random.Next( -30,30 );
                }
            }
            int[] sredneeznachenie = CalculateTemperatures(temperatures);
            Console.WriteLine("Среднее значение температуры для каждого месяца: ");
            for (int i = 0; i < 12; i++)
            {
                Console.WriteLine($"Месяц {i + 1}: {sredneeznachenie[i]}");
            }

        }
        static void Task4()
        {
            Console.WriteLine("Домашнее задание 6.1");
            string filename = "Text.txt";
            List<char> letters = new List<char> ( File.ReadAllText(filename).ToCharArray());
            int countvowels, countconsonants;
            Calculate2(letters, out countvowels, out countconsonants);
            Console.WriteLine($"Число гласных: {countvowels}");
            Console.WriteLine($"Число согласных: {countconsonants}");
        }
        static void Task5()
        {
            Console.WriteLine("Домашнее задание 6.2");
            Console.WriteLine("Программа для умножения матриц");
            var a = GetMatrix("A");
            var b = GetMatrix("B");
            Console.WriteLine("Матрица A:");
            PrintMatrix(a);
            Console.WriteLine("Матрица B:");
            PrintMatrix(b);
            LinkedList<LinkedList<int>> resultMatrix = MultiplyMatrix(a,b);
            Console.WriteLine("Результат умножения матриц:");
            PrintResultMatrix(resultMatrix);
        }
        static void Task6()
        {
            Random random = new Random();
            int[,] temperatures = new int[12, 30];
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    temperatures[i, j] = random.Next(-30, 30); //  случайныt температурs от -30 до 30
                }
            }

            Dictionary<string, int[]> srednieznacheniya = CalculateTemperatures2(temperatures);

            Console.WriteLine("Средние температуры по месяцам:");
            foreach (var a in srednieznacheniya)
            {
                int sum = 0;
                foreach (var temp in a.Value)
                {
                    sum += temp;
                }
                double sredneeznachenie = (double)sum / a.Value.Length;
                Console.WriteLine($"{a.Key}: {sredneeznachenie:F1} градусов Цельсия");
            }
        }
        // Метод для вычисления гласных и согласных 
        static void Calculate(char[] letters, out int vowels, out int consonants)
        {
            vowels = 0;
            consonants = 0;
            string rvowels = "aAeEёЁиИоОуУыЫэЭюЮяЯ";
            string rconsonants = "йЙцЦкКнНгГшШщЩзЗхХъЪфФвВпПрРлЛдДжЖчЧсСмМтТьЬбБ";
            foreach (char c in letters)
            {
                if (char.IsLetter(c))
                {
                    if (rvowels.Contains(c))
                    {
                        vowels++;
                    }
                    else if (rconsonants.Contains(c))
                    {
                        consonants++;
                    }
                }
            }
        }
        
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
            Task6();
        }
    }
}
