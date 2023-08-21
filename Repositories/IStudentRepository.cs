using FutureFacePractice.Models;

namespace FutureFacePractice.Repositories
{
    public interface IStudentRepository
    {
        public Task<List<Student>> GetAllStudents();
        public Task<Student> GetStudentById(int id);
        public Task<bool> AddStudent(Student student);
        public Task<bool> EditStudent(Student student);
        public Task<bool> DeleteStudent(Student student);

    }
}
