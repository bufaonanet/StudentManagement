using MongoDB.Driver;
using StudentManagement.Data;
using StudentManagement.Models;

namespace StudentManagement.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly IStudentContext _context;

    public StudentRepository(IStudentContext context)
    {
        _context = context;
    }

    public Student Create(Student student)
    {
        _context.Students.InsertOne(student);
        return student;
    }

    public IEnumerable<Student> Get()
    {
        return _context.Students.Find(s => true).ToList();
    }

    public Student Get(string id)
    {
        return _context.Students.Find(s => s.Id == id).FirstOrDefault();
    }

    public void Remove(string id)
    {
        _context.Students.DeleteOne(s => s.Id == id);
    }

    public void Update(string id, Student student)
    {
        _context.Students.ReplaceOne(s => s.Id == id, student);
    }
}