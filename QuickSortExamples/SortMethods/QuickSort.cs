using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSortExamples.SortMethods
{
    class QuickSort
    {
        public static List<int> RandomPivotQuickSort(List<int> list)
        {        
            if (list.Count < 2) { return list; } // Базовый случай           
            else
            {                              
                int pivot = list[new Random().Next(list.Count)]; // Определить опорную точку
                // Разделение элементов по спискам             
                var less = list.Where(item => item.CompareTo(pivot) < 0 && item != pivot).ToList(); // Список для элементов меньше опорного           
                var greater = list.Where(item => item.CompareTo(pivot) > 0 && item != pivot).ToList(); // Список для элементов больше опорного
                // Соединяем все в один список и возвращаем                 
                return RandomPivotQuickSort(less).Concat(list.Where(x => x == pivot)).Concat(RandomPivotQuickSort(greater)).ToList();
            }
        }

        public static List<int> ParallelQuickSort(object obj)
        {
            // Приведение obj к List<int>
            List<int> list = (List<int>)obj;          
            if (list.Count < 2) { return list; } // Базовый случай           
            else
            {                              
                int pivot = list[new Random().Next(list.Count)]; // Определить опорную точку
                // Разделение элементов по спискам             
                var less = list.Where(item => item < pivot && item != pivot).ToList();  // Список для элементов меньше опорного             
                var greater = list.Where(item => item > pivot && item != pivot).ToList();  // Список для элементов больше опорного
                // Создаем таски для рекурсивного случая со списками для элементов less и greather           
                Task<List<int>> tsk = Task<List<int>>.Factory.StartNew(ParallelQuickSort, less);
                Task<List<int>> tsk2 = Task<List<int>>.Factory.StartNew(ParallelQuickSort, greater);
                // Списки для результатов tsk и tsk2
                List<int> result = tsk.Result;
                List<int> result2 = tsk2.Result;
                // Соединяем все в один список и возвращаем   
                return result.Concat(list.Where(x => x == pivot)).Concat(result2).ToList();
            }
        }
    }
}
