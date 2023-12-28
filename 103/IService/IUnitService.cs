using _103.DTO;
using _103.Models;

namespace _103.IService
{
    public interface IUnitService
    {
        public Task<List<UnitList>> GetUnitListAsync();
        public Task<UnitList> GetUnitByIdAsync(int UnitID);
        public Task<int> AddUnitAsync(Unit unit);
        public Task<int> UpdateUnitAsync(Unit unit);
        public Task<int> DeleteUnitAsync(int UnitID);
        public Task<IEnumerable<UnitList>> FetchPaginatedUnit(int pageNumber, int pageSize); //pagination
        public Task<int> GetTotalUnit();
    }
}
