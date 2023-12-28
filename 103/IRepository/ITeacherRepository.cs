using _103.Models;
using Microsoft.AspNetCore.Mvc;

namespace _103.IRepository
{
    public interface ITeacherRepository
    {
        Task<List<Teacher>> GetTeacherListAsync();
        Task<Teacher> GetTeacherByIdAsync(int TeacherID);
        Task<int> AddTeacherAsync(Teacher teachers);
        Task<int> UpdateTeacherAsync(Teacher teachers);
        Task<int> DeleteTeacherAsync(int TeacherID);
        Task<IEnumerable<Teacher>> FetchPaginatedTeacher(int pageNumber, int pageSize); //pagination
        Task<int> GetTotalTeacher(); 

    }
}
