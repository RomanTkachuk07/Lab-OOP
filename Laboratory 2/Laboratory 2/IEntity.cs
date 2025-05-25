using System;
using System.Collections.Generic;

namespace Laboratory_2
{
    public interface IEntity
    {
        bool IsValid();
        string Info();
        bool Search(string query);
    }

    // Simple delegate for search
    public delegate bool SearchDelegate(string query);

    // Generic interface for storing data
    public interface IDatabase<T> where T : IEntity
    {
        void Add(T item);
        List<T> GetAll();
        T FindById(Guid id);
        List<T> Search(string query);
    }
}