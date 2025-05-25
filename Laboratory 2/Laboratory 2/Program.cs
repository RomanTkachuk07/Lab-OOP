using System;
using System.Collections.Generic;
using UniversitySystem;

namespace Laboratory_2
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== University System with Generics ===\n");

            // Create generic databases
            var studentDB = new Database<Student>();
            var professorDB = new Database<Professor>();

            // Create and add students
            var student1 = new Student(Guid.NewGuid(), "Alice Johnson", "Female", 20, "Computer Science", 3);
            var student2 = new Student(Guid.NewGuid(), "Bob Smith", "Male", 22, "Mathematics", 4);

            studentDB.Add(student1);
            studentDB.Add(student2);

            // Create and add professors
            var professor1 = new Professor(Guid.NewGuid(), "Dr. Emily Davis", "Female", 45, "Computer Science");
            var professor2 = new Professor(Guid.NewGuid(), "Dr. Michael Brown", "Male", 50, "Mathematics");

            professorDB.Add(professor1);
            professorDB.Add(professor2);

            // Demonstrate generic interface usage
            Console.WriteLine("=== Generic Interface Demo ===");
            IDatabase<Student> studentInterface = studentDB;
            IDatabase<Professor> professorInterface = professorDB;

            Console.WriteLine($"Students count: {studentInterface.GetAll().Count}");
            Console.WriteLine($"Professors count: {professorInterface.GetAll().Count}");

            // Display all using generic method
            studentDB.DisplayAll();
            professorDB.DisplayAll();

            // Search using generics
            Console.WriteLine("\n=== Generic Search Demo ===");
            var foundStudents = studentDB.Search("Alice");
            Console.WriteLine($"Found {foundStudents.Count} students matching 'Alice'");

            var foundProfessors = professorDB.Search("Computer");
            Console.WriteLine($"Found {foundProfessors.Count} professors matching 'Computer'");

            // Find by ID using generics
            Console.WriteLine("\n=== Generic FindById Demo ===");
            var foundStudent = studentDB.FindById(student1.Id);
            if (foundStudent != null)
            {
                Console.WriteLine($"Found student by ID: {foundStudent.Name}");
            }

            // Create university with our databases
            var university = new University(Guid.NewGuid(), "Tech University",
                studentDB.GetAll(),
                professorDB.GetAll());

            Console.WriteLine("\n=== University Info ===");
            university.Display();

            // Demonstrate interface (non-generic)
            Console.WriteLine("\n=== Interface Demo ===");
            IEntity entity = student1;
            Console.WriteLine($"Is Valid: {entity.IsValid()}");
            Console.WriteLine($"Search 'Alice': {entity.Search("Alice")}");

            // Demonstrate delegate
            Console.WriteLine("\n=== Delegate Demo ===");
            SearchDelegate searchDelegate = (query) => query.Length > 3;
            Console.WriteLine($"Delegate search 'test': {searchDelegate("test")}");
            Console.WriteLine($"Delegate search 'hi': {searchDelegate("hi")}");

            // Save to files
            Console.WriteLine("\n=== Saving to Files ===");
            try
            {
                foreach (var student in studentDB.GetAll())
                    FileManager.FileAdd(student);
                foreach (var professor in professorDB.GetAll())
                    FileManager.FileAdd(professor);
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