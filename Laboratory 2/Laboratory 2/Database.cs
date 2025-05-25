using System;
using System.Collections.Generic;
using System.Linq;
using UniversitySystem;

namespace Laboratory_2
{
    public class Database<T> : IDatabase<T> where T : Entity, IEntity
    {
        private List<T> items;

        public Database()
        {
            items = new List<T>();
        }

        public void Add(T item)
        {
            if (item != null && item.IsValid())
            {
                items.Add(item);
                Console.WriteLine($"Added {typeof(T).Name}");
            }
        }

        public List<T> GetAll()
        {
            return items;
        }

        // LINQ Methods

        public T FindById(Guid id)
        {
            // LINQ: Simple filtering
            return items.Where(item => item.Id == id).FirstOrDefault();
        }

        public List<T> Search(string query)
        {
            // LINQ: Filtering with search
            return items.Where(item => item.Search(query)).ToList();
        }


        // 1. LINQ Filtering - Filter by condition
        public List<T> FilterBy(Func<T, bool> condition)
        {
            return items.Where(condition).ToList();
        }

        // 2. LINQ Sorting - Sort ascending
        public List<T> SortAscending<TKey>(Func<T, TKey> keySelector)
        {
            return items.OrderBy(keySelector).ToList();
        }

        // 3. LINQ Sorting - Sort descending  
        public List<T> SortDescending<TKey>(Func<T, TKey> keySelector)
        {
            return items.OrderByDescending(keySelector).ToList();
        }

        // 4. LINQ Aggregation - Count items
        public int Count()
        {
            return items.Count();
        }

        // 5. LINQ Aggregation - Check if any match condition
        public bool Any(Func<T, bool> condition)
        {
            return items.Any(condition);
        }

        public void DisplayAll()
        {
            Console.WriteLine($"=== All {typeof(T).Name}s ===");
            foreach (var item in items)
            {
                if (item is Person person)
                    person.Display();
            }
        }
    }
}