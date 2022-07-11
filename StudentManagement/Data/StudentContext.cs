using MongoDB.Driver;
using StudentManagement.Configurations;
using StudentManagement.Models;

namespace StudentManagement.Data;

public class StudentContext : IStudentContext
{
    public StudentContext(IMongoClient mongoClient, IStudentStoreDatabaseSettings settings)
    {
        var database = mongoClient.GetDatabase(settings.DatabaseName);
        Students = database.GetCollection<Student>(settings.StudentCoursesCollectionName);

        StudenContextSeed.SeedData(Students);
    }

    public IMongoCollection<Student> Students { get; }

}
