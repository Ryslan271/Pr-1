using System.Collections;

namespace Pr_1_1
{
    public class Set<T> : IEnumerable<T>
    {
        private readonly HashSet<T> _sets;

        public IEnumerable<T> AllItems => _sets;

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

        // Создание нового обьекта класса
        protected Set<T> CreateEmptySet() =>
            new();

        /// <summary>
        /// Обьединение множеств
        /// </summary>
        public static Set<T> operator +(Set<T> a, Set<T> b)
        {
            var result = a.CreateEmptySet();
            foreach (var item in a.AllItems)
                result.Add(item);
            foreach (var item in b.AllItems)
                result.Add(item);
            return result;
        }

        /// <summary> 
        /// Пересечения множеств
        /// </summary>
        public static Set<T> operator -(Set<T> a, Set<T> b)
        {
            var result = a.CreateEmptySet();
            foreach (var item in a.AllItems)
                if (b.Contains(item))
                    result.Add(item);
            return result;
        }

        /// <summary>
        /// Разность множеств
        /// </summary>
        public static Set<T> operator /(Set<T> a, Set<T> b)
        {
            var result = a.CreateEmptySet();
            foreach (var item in a.AllItems)
                if (!b.Contains(item))
                    result.Add(item);
            return result;
        }

        public override string ToString() =>
            $"[{string.Join(", ", AllItems)}]";

        //Инициализация методов IEnumerable
        IEnumerator IEnumerable.GetEnumerator() =>
            (IEnumerator)AllItems;

        public IEnumerator<T> GetEnumerator() =>
            _sets.GetEnumerator();
    }
}
