using _103.Data;
using _103.DTO;
using _103.IRepository;
using _103.IService;
using _103.Models;

namespace _103.Service
{
    public class MarksService : IMarksService
    {
        private readonly IMarksRepository _marksRepository;

        public MarksService(IMarksRepository marksRepository)
        {
            _marksRepository = marksRepository;
        }

        public async Task<List<MarkList>> GetMarksListAsync()
        {
            return await _marksRepository.GetMarksListAsync();
        }

        public async Task<MarkList> GetMarksByIdAsync(int MarkID)
        {
            return await _marksRepository.GetMarksByIdAsync(MarkID);
        }

        public async Task<int> AddMarksAsync(Marks mark)
        {
            return await _marksRepository.AddMarksAsync(mark);
        }

        public async Task<int> UpdateMarksAsync(Marks mark)
        {
            return await _marksRepository.UpdateMarksAsync(mark);
        }

        public async Task<int> DeleteMarksAsync(int MarkID)
        {
            return await _marksRepository.DeleteMarksAsync(MarkID);
        }

        public async Task<int> EligibleCheckResult(Marks mark)
        {
            return await _marksRepository.EligibleCheckResult(mark);
        }

        public async Task<int> EligibleCheckDuplicate(Marks mark)
        {
            return await _marksRepository.EligibleCheckDuplicate(mark);
        }

       public async Task<int> EligibleCheckResultEdit(Marks mark)
        {
            return await _marksRepository.EligibleCheckResultEdit(mark);
        }

        public async Task<IEnumerable<MarkList>> FetchPaginatedMark(int pageNumber, int pageSize)
        {
            return await _marksRepository.FetchPaginatedMark(pageNumber, pageSize);
        }

        public async Task<List<MarkList>> GetStudentUnitAvailable(int studentID)
        {
            return await _marksRepository.GetStudentUnitAvailable(studentID);
        }

        public async Task<int> GetTotalMark()
        {
            return await _marksRepository.GetTotalMark();
        }

    }
}


    
