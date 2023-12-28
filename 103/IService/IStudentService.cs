using _103.Data;
using _103.DTO;
using _103.Models;
using System.Drawing.Printing;

namespace _103.IService
{
    public interface IStudentService
    {
        public Task<List<Student>> GetStudentListAsync();
        public Task<Student> GetStudentByIdAsync(int StudentID);
        public Task<int> AddStudentAsync(Student students);
        public Task<int> UpdateStudentAsync(Student students);
        public Task<int> DeleteStudentAsync(int StudentID);
        public Task<int> DuplicateEmailCheck(Student students);
        public Task<StudentList> GetStudentResultByID(int StudentID);
        public Task<IEnumerable<Student>> FetchPaginatedStudent(int pageNumber, int pageSize); //pagination
        public Task<int> GetTotalStudent();

    }
}
