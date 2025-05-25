using Laboratory_2;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UniversitySystem
{
    public class Entity
    {
        public Guid Id { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Entity(Guid id)
        {
            Id = id;
        }

        public virtual bool IsValid()
        {
            return Id != Guid.Empty;
        }

        public virtual string Info()
        {
            return "[" + Id.ToString() + "]";
        }

        public virtual string FileName { get; }

        public virtual bool Search(string query)
        {
            return Id.ToString().ToLower().Contains(query.ToLower());
        }
    }

    public class Person : Entity, IEntity
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public override string FileName => "Person.txt";

        public Person()
        {
            Name = string.Empty;
            Gender = string.Empty;
            Age = 0;
        }

        public Person(Guid id, string name, string gender, int age) : base(id)
        {
            Name = name;
            Gender = gender;
            Age = age;
        }

        public override string Info()
        {
            return $"{base.Info()} [{Name}][{Gender}][{Age}]";
        }

        public new bool IsValid()
        {
            return base.IsValid() &&
                   !string.IsNullOrEmpty(Name) &&
                   !string.IsNullOrEmpty(Gender) &&
                   Age > 0;
        }

        public SearchDelegate CustomSearchLogic { get; set; }
        public override bool Search(string query)
        {
            // Use delegate if provided, otherwise use default search
            if (CustomSearchLogic != null)
                return CustomSearchLogic(query);

            return base.Search(query) ||
                   Name.ToLower().Contains(query.ToLower()) ||
                   Gender.ToLower().Contains(query.ToLower()) ||
                   Age.ToString().Contains(query);
        }

        public void Display()
        {
            Console.WriteLine($"Person: {Name}, Age: {Age}, Gender: {Gender}");
        }
    }

    public class Student : Person
    {
        public string Speciality { get; set; }
        public int Grade { get; set; }
        public override string FileName => "Student.txt";

        public Student()
        {
            Speciality = string.Empty;
            Grade = 0;
        }

        public Student(Guid id, string name, string gender, int age, string speciality, int grade)
            : base(id, name, gender, age)
        {
            Speciality = speciality;
            Grade = grade;
        }

        public sealed override string Info()
        {
            return $"{base.Info()}[{Speciality}][{Grade}]";
        }

        public new bool IsValid()
        {
            return base.IsValid() && !string.IsNullOrEmpty(Speciality) && Grade > 0;
        }

        public override bool Search(string query)
        {
            return base.Search(query) ||
                   Speciality.ToLower().Contains(query.ToLower()) ||
                   Grade.ToString().Contains(query);
        }

        public new void Display()
        {
            Console.WriteLine($"Student: {Name}, Speciality: {Speciality}, Grade: {Grade}");
        }
    }

    public sealed class Professor : Person
    {
        public string Faculty;
        public sealed override string FileName => "Professor.txt";

        public Professor()
        {
            Faculty = string.Empty;
        }

        public Professor(Guid id, string name, string gender, int age, string faculty)
            : base(id, name, gender, age)
        {
            Faculty = faculty;
        }

        public sealed override string Info()
        {
            return $"{base.Info()}[{Faculty}]";
        }

        public new bool IsValid()
        {
            return base.IsValid() && !string.IsNullOrEmpty(Faculty);
        }

        public override bool Search(string query)
        {
            return base.Search(query) ||
                   Faculty.ToLower().Contains(query.ToLower());
        }

        public new void Display()
        {
            Console.WriteLine($"Professor: {Name}, Faculty: {Faculty}");
        }
    }

    public class University : Entity, IEntity
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; }
        public List<Professor> Professors { get; set; }
        public override string FileName => "University.txt";

        public University()
        {
            Students = new List<Student>();
            Professors = new List<Professor>();
            Name = string.Empty;
        }

        public University(Guid id, string name, List<Student> students, List<Professor> professors)
            : base(id)
        {
            Name = name;
            Students = students ?? new List<Student>();
            Professors = professors ?? new List<Professor>();
        }

        public new bool IsValid()
        {
            return base.IsValid() && !string.IsNullOrEmpty(Name) &&
                   Professors.Count > 0 && Students.Count > 0;
        }

        public override string Info()
        {
            var studentsId = new List<string>();
            foreach (var student in Students)
            {
                studentsId.Add(student.Id.ToString());
            }
            var professorId = new List<string>();
            foreach (var professor in Professors)
            {
                professorId.Add(professor.Id.ToString());
            }

            var studentsIdStr = string.Join(",", studentsId);
            var professorIdStr = string.Join(",", professorId);
            return $"[{base.Info()}] [{Name}] [Students: {studentsIdStr}] [Professors: {professorIdStr}]";
        }

        public override bool Search(string query)
        {
            return base.Search(query) ||
                   Name.ToLower().Contains(query.ToLower()) ||
                   Students.Any(s => s.Search(query)) ||
                   Professors.Any(p => p.Search(query));
        }

        public void Display()
        {
            Console.WriteLine($"University: {Name}");
            Console.WriteLine($"Students: {Students.Count}, Professors: {Professors.Count}");
        }
    }
}