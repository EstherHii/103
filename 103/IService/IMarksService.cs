using _103.DTO;
using _103.Models;

namespace _103.IService
{
    public interface IMarksService
    {
        public Task<List<MarkList>> GetMarksListAsync();
        public Task<MarkList> GetMarksByIdAsync(int MarkID);
        public Task<int> AddMarksAsync(Marks mark);
        public Task<int> UpdateMarksAsync(Marks mark);
        public Task<int> DeleteMarksAsync(int MarkID);
        public Task<int> EligibleCheckResult(Marks mark);
        public Task<int> EligibleCheckDuplicate(Marks mark);
        public Task<int> EligibleCheckResultEdit(Marks mark);
        public Task<IEnumerable<MarkList>> FetchPaginatedMark(int pageNumber, int pageSize); //pagination
        public Task<List<MarkList>> GetStudentUnitAvailable(int studentID);
        public Task<int> GetTotalMark();

    }
}
