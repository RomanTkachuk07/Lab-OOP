using System;
using System.Collections.Generic;
using UniversitySystem;

namespace Laboratory_2
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== University System ===\n");

            // Create students
            var student1 = new Student(Guid.NewGuid(), "Alice Johnson", "Female", 20, "Computer Science", 3);
            var student2 = new Student(Guid.NewGuid(), "Bob Smith", "Male", 22, "Mathematics", 4);

            // Create professors
            var professor1 = new Professor(Guid.NewGuid(), "Dr. Emily Davis", "Female", 45, "Computer Science");
            var professor2 = new Professor(Guid.NewGuid(), "Dr. Michael Brown", "Male", 50, "Mathematics");

            // Create university
            var university = new University(Guid.NewGuid(), "Tech University",
                new List<Student> { student1, student2 },
                new List<Professor> { professor1, professor2 });

            // Display information
            Console.WriteLine("=== University Info ===");
            university.Display();

            Console.WriteLine("\n=== Students ===");
            foreach (var student in university.Students)
            {
                student.Display();
            }

            Console.WriteLine("\n=== Professors ===");
            foreach (var professor in university.Professors)
            {
                professor.Display();
            }

            // Demonstrate interface usage
            Console.WriteLine("\n=== Interface Demo ===");
            IEntity entity = student1;
            Console.WriteLine($"Is Valid: {entity.IsValid()}");
            Console.WriteLine($"Info: {entity.Info()}");
            Console.WriteLine($"Search 'Alice': {entity.Search("Alice")}");

            // Demonstrate delegate usage
            Console.WriteLine("\n=== Delegate Demo ===");
            student1.CustomSearchLogic = (query) => {
                Console.WriteLine($"Using custom search for: {query}");
                return student1.Name.ToUpper().Contains(query.ToUpper()); // Case-sensitive search
            };

            Console.WriteLine($"Custom search for 'ALICE': {student1.Search("ALICE")}");
            Console.WriteLine($"Normal search for 'bob': {student2.Search("bob")}");

            // Save to files
            Console.WriteLine("\n=== Saving to Files ===");
            try
            {
                FileManager.FileAdd(student1);
                FileManager.FileAdd(professor1);
                FileManager.FileAdd(university);
                Console.WriteLine("Files saved successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}