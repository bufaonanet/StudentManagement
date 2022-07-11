using StudentManagement.Models;

namespace StudentManagement.Repositories;

public interface IStudentRepository
{
    IEnumerable<Student> Get();
    Student Get(string id);
    Student Create(Student student);
    void Update(string id, Student student);
    void Remove(string id);
}