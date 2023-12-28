using _103.Data;
using _103.DTO;
using _103.IRepository;
using _103.IService;
using _103.Models;

namespace _103.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        //pagination
        public async Task<IEnumerable<Student>> FetchPaginatedStudent(int pageNumber, int pageSize)
        {
            return await _studentRepository.FetchPaginatedStudent(pageNumber, pageSize);
        }

        public async Task<List<Student>> GetStudentListAsync()
        {
            return await _studentRepository.GetStudentListAsync();
        }
        public async Task<Student> GetStudentByIdAsync(int StudentID)
        {
            return await _studentRepository.GetStudentByIdAsync(StudentID);
        }

        public async Task<int> AddStudentAsync(Student students)
        {
            return await _studentRepository.AddStudentAsync(students);
        }

        public async Task<int> UpdateStudentAsync(Student students)
        {
            return await _studentRepository.UpdateStudentAsync(students);
        }

        public async Task<int> DeleteStudentAsync(int StudentID)
        {
            return await _studentRepository.DeleteStudentAsync(StudentID);
        }
        public async Task<int> DuplicateEmailCheck(Student students)
        {
            return await _studentRepository.DuplicateEmailCheck(students);
        }

        public async Task<StudentList> GetStudentResultByID(int StudentID)
        {
            return await _studentRepository.GetStudentResultByID(StudentID);
        }

        public async Task<int> GetTotalStudent()
        {
            return await _studentRepository.GetTotalStudent();
        }
    }
}

