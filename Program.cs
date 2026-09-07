using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Pr_1_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var alf = new HashSet<char>("абвгдеёжзийклмнопрстуфхцчшщъыьэюя"); // алфовит

            // Первое задание "Даны множества А и В. Найти объединение, пересечение и разность множеств"
            var A1 = new Set<int> ([2, 4, 6, 8, 10]);
            var B1 = new Set<int>([4, 8, 12, 16, 20]);

            var A2 = new Set<int> ([3, 6, 9, 12, 15 ]);
            var B2 = new Set<int> ([1, 3, 5, 7, 9]);

            var A3 = new Set<double> ([1, 0.5, 0.33, 0.25]);
            var B3 = new Set<double> ([1, 0.5, 0.25, 0.125, 0.0625]);

            var A4 = new Set<double> ([0.1, 0.2, 0.3]);
            var B4 = new Set<double> ([0, 0.1, 0.05, 0.033]);

            //Вывод результата первого задания
            // GetResultOneTask(A1, B1);
            // GetResultOneTask(A2, B2);
            // GetResultOneTask(A3, B3);
            // GetResultOneTask(A4, B4);

            //Второе задание "Найти A∩(B∪C), (A∪B)∩C и U\(A∪B∪C)"
            var A5 = new Set<int>([1, 2, 4, 5, 6]);
            var B5 = new Set<int>([1, 4, 5, 7]);
            var C5 = new Set<int>([2, 6, 7, 8]);
            var U5 = new Set<int>([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);

            var A6 = new Set<char>(['a', 'b', 'c']);
            var B6 = new Set<char>(['c', 'd', 'e']);
            var C6 = new Set<char>(['a', 'e', 'f']);
            var U6 = new Set<char>(['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h']);

            var A7 = new Set<char>(['л', 'о', 'г', 'и', 'к', 'а']);
            var B7 = new Set<char>(['у', 'р', 'о', 'к']);
            var C7 = new Set<char>(['г', 'р', 'у', 'п', 'п', 'а']);
            var U7 = new Set<char>();
            foreach (var item in alf)
                U7.Add(item);

            // Выпод результата второго задания
            GetResultTwoTask(A5, B5, C5, U5);
            GetResultTwoTask(A6, B6, C6, U6);
            GetResultTwoTask(A7, B7, C7, U7);


        }

        /// <summary>
        /// Вывод и подсчет данных по первому заданию
        /// </summary>
        protected static void GetResultOneTask<T>(Set<T> A, Set<T> B)
        {
            GetInitialData(
                new Dictionary<string, Set<T>>()
                    {
                        ["A"] = A,
                        ["B"] = B
                    });

            Console.WriteLine($"A + B = [{string.Join(", ", A.Union(B).AllItems())}]");
            Console.WriteLine($"A - B = [{string.Join(", ", A.Intersect(B).AllItems())}]");
            Console.WriteLine($"A \\ B = [{string.Join(", ", A.Difference(B).AllItems())}]");
            Console.WriteLine();
        }

        /// <summary>
        /// Вывод и подсчет данных по второму заданию заданию
        /// </summary>
        protected static void GetResultTwoTask<T>(Set<T> A, Set<T> B, Set<T> C, Set<T> U)
        {
            GetInitialData(
                new Dictionary<string, Set<T>>()
                {
                    ["A"] = A,
                    ["B"] = B,
                    ["C"] = C,
                    ["U"] = U
                });

            Console.WriteLine($"A - (B + C) = [{string.Join(", ", A.Intersect(B.Union(C)).AllItems())}]"); // A ∩ (B ∪ C)
            Console.WriteLine($"(A + B) - C = [{string.Join(", ", (A.Union(B)).Intersect(C).AllItems())}]"); // (A ∪ B) ∩ C
            Console.WriteLine($"U \\ (A + B + C) = [{string.Join(", ", U.Difference(A.Union(B.Union(C))).AllItems())}]"); // U \ (A ∪ B ∪ C)
            Console.WriteLine();
        }

        /// <summary>
        /// Вывод первоначальных данных
        /// </summary>
        /// <param name="items">массив множества</param>
        protected static void GetInitialData<T>(Dictionary<string, Set<T>> items)
        {
            foreach (var item in items)
                Console.WriteLine($"{item.Key} = [{string.Join(", ", item.Value.AllItems())}]");
            Console.WriteLine();
        }

    }

    public class Set<T> : IEnumerable<T>
    {
        private readonly HashSet<T> _sets;

        public void Add(T item) => _sets.Add(item);

        public bool Contains(T item) => _sets.Contains(item);

        public void Remove(T item) => _sets.Remove(item);

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="items"><T></param>
        public Set() =>
            _sets = [];

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="items">List<T> items</param>
        public Set(List<T> items) =>
            _sets = [.. items];

        // Служебные методы абстракных классов
        protected Set<T> CreateEmptySet() =>
            new();

        /// <summary>
        /// Вывод всех элементов класса
        /// </summary>
        /// <returns>IEnumerable<T></returns>
        public IEnumerable<T> AllItems() =>
            _sets;

        /// <summary>
        /// Обьединение множеств
        /// </summary>
        public Set<T> Union(Set<T> other)
        {
            var result = CreateEmptySet();
            foreach (var item in this.AllItems())
                result.Add(item);
            foreach (var item in other.AllItems())
                result.Add(item);
            return result;
        }

        /// <summary> 
        /// Пересечения множеств
        /// </summary>
        public Set<T> Intersect(Set<T> other)
        {
            var result = CreateEmptySet();
            foreach (var item in this.AllItems())
                if (other.Contains(item))
                    result.Add(item);

            return result;
        }

        /// <summary>
        /// Разность множеств
        /// </summary>
        public Set<T> Difference(Set<T> other)
        {
            var result = CreateEmptySet();
            foreach (var item in this.AllItems())
                if (!other.Contains(item))
                    result.Add(item);

            return result;
        }

        //Инициализация методов IEnumerable
        IEnumerator IEnumerable.GetEnumerator() =>
            (IEnumerator)AllItems();

        public IEnumerator<T> GetEnumerator() =>
            throw new NotImplementedException();
    }
}
