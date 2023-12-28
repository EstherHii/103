using _103.DTO;
using _103.Models;

namespace _103.IRepository
{
    public interface IUnitRepository
    {
        Task<List<UnitList>> GetUnitListAsync();
        Task<UnitList> GetUnitByIdAsync(int UnitID);
        Task<int> AddUnitAsync(Unit unit);
        Task<int> UpdateUnitAsync(Unit unit);
        Task<int> DeleteUnitAsync(int UnitID);
        Task<IEnumerable<UnitList>> FetchPaginatedUnit(int pageNumber, int pageSize); //pagination
        Task<int>GetTotalUnit(); 
    }
}
