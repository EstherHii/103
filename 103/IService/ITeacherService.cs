using _103.Data;
using _103.Models;

namespace _103.IService
{
    public interface ITeacherService
    {
        public Task<List<Teacher>> GetTeacherListAsync();
        public Task<Teacher> GetTeacherByIdAsync(int TeacherID);
        public Task <int> AddTeacherAsync(Teacher teachers);
        public Task<int> UpdateTeacherAsync(Teacher teachers);
        public Task<int> DeleteTeacherAsync(int TeacherID); 
        public Task<IEnumerable<Teacher>> FetchPaginatedTeacher(int pageNumber, int pageSize);  //pagination
        public Task<int> GetTotalTeacher();

    }
}
