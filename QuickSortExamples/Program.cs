using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickSortExamples.SortMethods;
using System.Diagnostics;

namespace QuickSortExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Quick Sort *****");
            Random r = new Random();
            List<int> demonstrateList = new List<int>();           
            for (int i = 0; i < 10; i++)
            {
                demonstrateList.Add(r.Next(1, 100));
            }
            Console.WriteLine("Демонстрация работоспособности быстрой параллельной сортировки");
            ShowSort(demonstrateList);
            Console.WriteLine();
            List<int> list = new List<int>();                     
            // Заполнить список случайными числами
            for (int i = 0; i < 10000000; i++)
            {
                list.Add(r.Next(1, 10000));
            }
            Console.WriteLine("Сравнение времени работы параллельной и однопочной быстрой сортировки");
            TenMillionsItemsSort(list);
            Console.WriteLine();
            TenMillionsItemsSortParallel(list);
            Console.ReadKey();         
        }

        static void ShowSort(List<int> list)
        {
            Stopwatch sw = new Stopwatch();
            Console.Write("\nНеотсортированный массив:");
            foreach (var num in list)
                Console.Write($"'{num}' ");
            Console.WriteLine();
            sw.Reset();
            sw.Start();
            list = QuickSort.ParallelQuickSort(list);
            sw.Stop();
            Console.Write("\nОтсортированный массив:");
            foreach (var num in list)
                Console.Write($"'{num}' ");
            // Вывести время сортировки
            Console.WriteLine("\n\nВремя сортировки: {0} миллисек.", (sw.Elapsed.TotalMilliseconds).ToString());
        }

        static void TenMillionsItemsSortParallel(List<int> list)
        {
            Stopwatch sw = new Stopwatch();
            Console.Write("\nНачата параллельная сортировка списка из 10M элементов");                    
            sw.Reset();
            sw.Start();
            list = QuickSort.ParallelQuickSort(list);
            sw.Stop();
            Console.Write("\nСписок отсортирован");         
            // Вывести время сортировки
            Console.WriteLine("\n\nВремя сортировки: {0} миллисек.", (sw.Elapsed.TotalMilliseconds).ToString());
        }

        static void TenMillionsItemsSort(List<int> list)
        {
            Stopwatch sw = new Stopwatch();
            Console.Write("\nНачата непараллельная сортировка списка из 10M элементов");
            Console.WriteLine();
            sw.Reset();
            sw.Start();
            list = QuickSort.RandomPivotQuickSort(list);
            sw.Stop();
            Console.Write("\nСписок отсортирован");
            // Вывести время сортировки
            Console.WriteLine("\n\nВремя сортировки: {0} миллисек.", (sw.Elapsed.TotalMilliseconds).ToString());
        }
    }
}
