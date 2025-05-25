using System;
using System.Collections.Generic;
using System.Linq;
using UniversitySystem;

namespace Laboratory_2
{
    // Generic class to store any type of entity
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
                Console.WriteLine($"Added {typeof(T).Name}: {item.Info()}");
            }
        }

        public List<T> GetAll()
        {
            return items;
        }

        public T FindById(Guid id)
        {
            return items.FirstOrDefault(item => item.Id == id);
        }

        public List<T> Search(string query)
        {
            return items.Where(item => item.Search(query)).ToList();
        }

        public int Count()
        {
            return items.Count;
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