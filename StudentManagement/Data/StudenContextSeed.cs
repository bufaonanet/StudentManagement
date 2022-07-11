using MongoDB.Driver;
using StudentManagement.Models;

namespace StudentManagement.Data;

public class StudenContextSeed
{
    public static void SeedData(IMongoCollection<Student> studentsCollection)
    {
        bool existStudents = studentsCollection.Find(p => true).Any();
        if (!existStudents)
        {
            studentsCollection.InsertMany(GetStudents());
        }
    }

    private static IEnumerable<Student> GetStudents()
    {
        return new List<Student>
        {
            new Student
            {
                Id  = "62cc828a0b394ac8301c5469",
                Age = 20,
                Courses = new[] { "ASP.Net", "Mongo", "C#"},
                Gender = "Male",
                IsGraduated = true,
                Name = "Douglas"
            },
            new Student
            {
                Id  = "62cc828a0b394ac8301c5470",
                Age = 35,
                Courses = new[] { "Angular", "Java Script","Mongo"},
                Gender = "Male",
                IsGraduated = true,
                Name = "José"
            },
            new Student
            {
                Id  = "62cc828a0b394ac8301c5471",
                Age = 20,
                Courses = new[] { "HTML", "Java Script","CSS"},
                Gender = "Female",
                IsGraduated = false,
                Name = "Maria"
            }
        };

    }


}
