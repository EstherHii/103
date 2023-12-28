using _103.Data;
using _103.DTO;
using _103.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;
using System.Threading.Tasks;

namespace _103.IRepository
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudentListAsync();
        Task<Student> GetStudentByIdAsync(int StudentID);
        Task<int> AddStudentAsync(Student students);
        Task<int> UpdateStudentAsync(Student students);
        Task<int> DeleteStudentAsync(int StudentID);
        Task<int> DuplicateEmailCheck(Student students);
        Task<StudentList> GetStudentResultByID(int StudentID);
        Task<IEnumerable<Student>> FetchPaginatedStudent(int pageNumber, int pageSize);
        Task<int> GetTotalStudent();

    }
}
