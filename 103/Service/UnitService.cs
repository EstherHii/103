using _103.IService;
using _103.Models;
using _103.Data;
using _103.IRepository;
using _103.DTO;
namespace _103.Service
{
    public class UnitService: IUnitService
    {
        private readonly IUnitRepository _unitRepository;

        public UnitService(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }

        public async Task<List<UnitList>> GetUnitListAsync()
        {
            return await _unitRepository.GetUnitListAsync();
        }

        public async Task<UnitList> GetUnitByIdAsync(int UnitID)
        {
            return await _unitRepository.GetUnitByIdAsync(UnitID);
        }

        public async Task<int> AddUnitAsync(Unit units)
        {
            return await _unitRepository.AddUnitAsync(units);
        }

        public async Task<int> UpdateUnitAsync(Unit units)
        {
            return await _unitRepository.UpdateUnitAsync(units);
        }

        public async Task<int> DeleteUnitAsync(int UnitID)
        {
            return await _unitRepository.DeleteUnitAsync(UnitID);
        }

        public async Task<IEnumerable<UnitList>> FetchPaginatedUnit(int pageNumber, int pageSize)
        {
            return await _unitRepository.FetchPaginatedUnit(pageNumber, pageSize);
        }

        public async Task<int> GetTotalUnit()
        {
            return await _unitRepository.GetTotalUnit();
        }
    }

}
