using System;

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
}