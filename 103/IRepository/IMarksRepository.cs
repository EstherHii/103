using _103.DTO;
using _103.Models;

namespace _103.IRepository
{
    public interface IMarksRepository
    {
        Task<List<MarkList>> GetMarksListAsync();
        Task<MarkList> GetMarksByIdAsync(int MarkID);
        Task<int> AddMarksAsync(Marks mark);
        Task<int> UpdateMarksAsync(Marks mark);
        Task<int> DeleteMarksAsync(int MarkID);
        Task<int> EligibleCheckResult(Marks mark);
        Task<int> EligibleCheckDuplicate(Marks mark);
        Task<int> EligibleCheckResultEdit(Marks mark);
        Task<IEnumerable<MarkList>> FetchPaginatedMark(int pageNumber, int pageSize); //pagination
        Task<List<MarkList>> GetStudentUnitAvailable(int studentID);
        Task<int> GetTotalMark();
    }
}
