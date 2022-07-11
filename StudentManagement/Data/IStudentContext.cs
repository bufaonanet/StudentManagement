using MongoDB.Driver;
using StudentManagement.Models;

namespace StudentManagement.Data;

public interface IStudentContext
{
    IMongoCollection<Student> Students { get; }
}