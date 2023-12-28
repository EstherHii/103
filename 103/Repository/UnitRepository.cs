using _103.Data;
using _103.IRepository;
using _103.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Dapper;
using _103.DTO;

namespace _103.Repository
{
    public class UnitRepository : IUnitRepository
    {
        private readonly UniDbContext dbContext;
        private readonly IDbConnection _connection;

        public UnitRepository(UniDbContext dbContext)
        {
            this.dbContext = dbContext;
            _connection = dbContext._connection;
        }

        public async Task<List<UnitList>> GetUnitListAsync()
        {
            var result = await _connection.QueryAsync<UnitList>("GetUnitList", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<UnitList> GetUnitByIdAsync(int UnitID)
        {
            var param = new DynamicParameters();
            param.Add("@UnitID", UnitID);
            var result = await _connection.QueryAsync<UnitList>("GetUnitByID", param, commandType: CommandType.StoredProcedure);
            return result.ToList().First(); 
        }

        public async Task<int> AddUnitAsync(Unit units)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@UnitName", units.UnitName));
            parameter.Add(new SqlParameter("@TeacherID", units.TeacherID));
            parameter.Add(new SqlParameter("@Schedule", units.Schedule));
            parameter.Add(new SqlParameter("@IsDeleted", units.IsDeleted));


            var result = await dbContext.Database
             .ExecuteSqlRawAsync(@"exec AddNewUnit @UnitName, @TeacherID, @Schedule, @IsDeleted", parameter.ToArray());
            return result;
        }

        public async Task<int> UpdateUnitAsync(Unit unit)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@UnitID", unit.UnitID));
            parameter.Add(new SqlParameter("@UnitName", unit.UnitName));
            parameter.Add(new SqlParameter("@TeacherID", unit.TeacherID));
            parameter.Add(new SqlParameter("@Schedule", unit.Schedule));

            var result = await dbContext.Database
             .ExecuteSqlRawAsync(@"exec UpdateUnit @UnitID, @UnitName, @TeacherID, @Schedule", parameter.ToArray());

            return result;
        }

        public async Task<int> DeleteUnitAsync(int UnitID)
        {
            return await dbContext.Database.ExecuteSqlInterpolatedAsync($"DeleteUnitByID {UnitID}");
        }

        public async Task<IEnumerable<UnitList>> FetchPaginatedUnit(int pageNumber, int pageSize) //pagination
        {
            var param = new DynamicParameters();
            param.Add("@pageNumber", pageNumber);
            param.Add("@PageSize", pageSize);

            var result = await _connection.QueryAsync<UnitList>("GetUnitPagination", param, commandType: CommandType.StoredProcedure);
            return result;
        }

        public async Task<int> GetTotalUnit()
        {
            int TotalUnitCount = await _connection.ExecuteScalarAsync<int>("GetTotalUnit");
            return TotalUnitCount;
        }
    }

}

