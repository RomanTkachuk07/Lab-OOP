using System;
using System.Collections.Generic;
using System.Linq;
using UniversitySystem;

namespace Laboratory_2
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== University System with LINQ ===\n");

            // Create databases and add data
            var studentDB = new Database<Student>();
            var professorDB = new Database<Professor>();

            // Add more students for better LINQ demonstration
            studentDB.Add(new Student(Guid.NewGuid(), "Alice Johnson", "Female", 20, "Computer Science", 3));
            studentDB.Add(new Student(Guid.NewGuid(), "Bob Smith", "Male", 22, "Mathematics", 4));
            studentDB.Add(new Student(Guid.NewGuid(), "Charlie Brown", "Male", 19, "Physics", 2));
            studentDB.Add(new Student(Guid.NewGuid(), "Diana Prince", "Female", 21, "Computer Science", 5));

            // Add professors
            professorDB.Add(new Professor(Guid.NewGuid(), "Dr. Emily Davis", "Female", 45, "Computer Science"));
            professorDB.Add(new Professor(Guid.NewGuid(), "Dr. Michael Brown", "Male", 50, "Mathematics"));
            professorDB.Add(new Professor(Guid.NewGuid(), "Dr. Sarah Wilson", "Female", 38, "Physics"));

            Console.WriteLine("=== 1. LINQ FILTERING ===");

            // Filter students by speciality
            var csStudents = studentDB.FilterBy(s => s.Speciality == "Computer Science");
            Console.WriteLine($"Computer Science students: {csStudents.Count}");
            foreach (var student in csStudents)
            {
                student.Display();
            }

            // Filter students by grade
            var topStudents = studentDB.FilterBy(s => s.Grade >= 4);
            Console.WriteLine($"\nTop students (grade >= 4): {topStudents.Count}");
            foreach (var student in topStudents)
            {
                student.Display();
            }

            // Filter professors by age
            var youngProfessors = professorDB.FilterBy(p => p.Age < 45);
            Console.WriteLine($"\nYoung professors (age < 45): {youngProfessors.Count}");
            foreach (var prof in youngProfessors)
            {
                prof.Display();
            }

            Console.WriteLine("\n=== 2. LINQ SORTING ===");

            // Sort students by name (ascending)
            var studentsByName = studentDB.SortAscending(s => s.Name);
            Console.WriteLine("Students sorted by name (A-Z):");
            foreach (var student in studentsByName)
            {
                Console.WriteLine($"  {student.Name}");
            }

            // Sort students by age (descending)
            var studentsByAge = studentDB.SortDescending(s => s.Age);
            Console.WriteLine("\nStudents sorted by age (oldest first):");
            foreach (var student in studentsByAge)
            {
                Console.WriteLine($"  {student.Name} - {student.Age} years old");
            }

            // Sort students by grade (descending)
            var studentsByGrade = studentDB.SortDescending(s => s.Grade);
            Console.WriteLine("\nStudents sorted by grade (highest first):");
            foreach (var student in studentsByGrade)
            {
                Console.WriteLine($"  {student.Name} - Grade {student.Grade}");
            }

            Console.WriteLine("\n=== 3. LINQ AGGREGATION ===");

            // Count total items
            Console.WriteLine($"Total students: {studentDB.Count()}");
            Console.WriteLine($"Total professors: {professorDB.Count()}");

            // Check if any match condition
            var hasYoungStudents = studentDB.Any(s => s.Age < 20);
            Console.WriteLine($"Has students under 20: {hasYoungStudents}");

            var hasFemaleProfessors = professorDB.Any(p => p.Gender == "Female");
            Console.WriteLine($"Has female professors: {hasFemaleProfessors}");

            // More aggregation using LINQ directly on lists
            var allStudents = studentDB.GetAll();

            var averageAge = allStudents.Average(s => s.Age);
            Console.WriteLine($"Average student age: {averageAge:F1}");

            var maxGrade = allStudents.Max(s => s.Grade);
            Console.WriteLine($"Highest grade: {maxGrade}");

            var minAge = allStudents.Min(s => s.Age);
            Console.WriteLine($"Youngest student age: {minAge}");

            var totalGrades = allStudents.Sum(s => s.Grade);
            Console.WriteLine($"Sum of all grades: {totalGrades}");

            Console.WriteLine("\n=== 4. COMPLEX LINQ QUERIES ===");

            // Chain multiple LINQ operations
            var topCSStudents = allStudents
                .Where(s => s.Speciality == "Computer Science")  // Filter
                .Where(s => s.Grade >= 3)                        // Filter more
                .OrderByDescending(s => s.Grade)                 // Sort
                .Take(2)                                         // Take top 2
                .ToList();

            Console.WriteLine("Top 2 Computer Science students:");
            foreach (var student in topCSStudents)
            {
                student.Display();
            }

            // Group students by speciality
            var groupedStudents = allStudents
                .GroupBy(s => s.Speciality)
                .ToList();

            Console.WriteLine("\nStudents grouped by speciality:");
            foreach (var group in groupedStudents)
            {
                Console.WriteLine($"{group.Key}: {group.Count()} students");
            }

            Console.WriteLine("\n=== Regular Features Still Work ===");

            // Create university
            var university = new University(Guid.NewGuid(), "Tech University",
                studentDB.GetAll(), professorDB.GetAll());
            university.Display();

            // Interface demo
            IEntity entity = allStudents.First();
            Console.WriteLine($"First student valid: {entity.IsValid()}");

            // Delegate demo
            SearchDelegate searchDelegate = (query) => query.Length > 3;
            Console.WriteLine($"Delegate search 'test': {searchDelegate("test")}");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}