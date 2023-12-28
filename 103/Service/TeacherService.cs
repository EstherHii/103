using _103.IService;
using _103.Models;
using _103.Data;
using _103.IRepository;
using _103.Repository;

namespace _103.Service
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        public async Task<List<Teacher>> GetTeacherListAsync()
        {
            return await _teacherRepository.GetTeacherListAsync();
        }

        public async Task<Teacher> GetTeacherByIdAsync(int TeacherID)
        {
            return await _teacherRepository.GetTeacherByIdAsync(TeacherID);
        }

        public async Task<int> AddTeacherAsync(Teacher teachers)
        {
            return await _teacherRepository.AddTeacherAsync(teachers);
        }

        public async Task<int> UpdateTeacherAsync(Teacher teachers)
        {
            return await _teacherRepository.UpdateTeacherAsync(teachers);
        }

        public async Task<int> DeleteTeacherAsync(int TeacherID)
        {
            return await _teacherRepository.DeleteTeacherAsync(TeacherID);
        }

        public async Task<IEnumerable<Teacher>> FetchPaginatedTeacher(int pageNumber, int pageSize) //pagination
        {
            return await _teacherRepository.FetchPaginatedTeacher(pageNumber, pageSize);
        }

        public async Task<int>GetTotalTeacher()
        {
            return await _teacherRepository.GetTotalTeacher();
        }
    }

 }


