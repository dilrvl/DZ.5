using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadachi
{
    internal class Program
    { // Метод для вывода списка идентификаторов в консоль
        static void Printik(List<string> list)
        {
            foreach (string f in list)
            {
                Console.WriteLine(f);
            }
        }
        // Метод для перемешивания картинок в списке 
        static void Peremeshannyi(List<string> list)
        {
            Random random = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                string value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        static void Task1()
        {
            Console.WriteLine("Домашнее задание 1");
            // Создаем список для хранения идентификаторов скачанных картинок
            List<string> imageList = new List<string>();
            for (int i = 1; i <= 32; i++)
            {
                imageList.Add($"image{i}.jpg");
                imageList.Add($"image{i}.jpg");
            }
            // Перемешивание списка картинок
            Peremeshannyi(imageList);
            // Вывод изначального списка
            Console.WriteLine("Изначальный список:");
            Printik(imageList);
            // Вывод перемешанного списка
            Console.WriteLine("nПеремешанный список:");
            Printik(imageList);
        }
        static void Main(string[] args)
        {
            Task1();
        }
    }
}
