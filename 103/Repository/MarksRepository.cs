using _103.Data;
using _103.IRepository;
using _103.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using _103.DTO;
using System.Data;
using Dapper;

namespace _103.Repository
{
    public class MarksRepository : IMarksRepository
    {
        private readonly UniDbContext dbContext;
        private readonly SqlConnection _connection;


        public MarksRepository(UniDbContext dbContext)
        {
            this.dbContext = dbContext;
            _connection = dbContext._connection;
        }

        public async Task<List<MarkList>> GetMarksListAsync()
        {
            var result = await _connection.QueryAsync<MarkList>("GetMarkList", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<MarkList> GetMarksByIdAsync(int MarkID)
        {
            var param = new DynamicParameters();
            param.Add("@MarkID", MarkID);
            var result = await _connection.QueryAsync<MarkList>("GetMarksByID", param, commandType: CommandType.StoredProcedure);
            return result.ToList().First();
        }

        public async Task<int> AddMarksAsync(Marks mark)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@StudentID", mark.StudentID));
            parameter.Add(new SqlParameter("@UnitID", mark.UnitID));
            parameter.Add(new SqlParameter("@Mark", mark.Mark));
            parameter.Add(new SqlParameter("@Grade", mark.Grade));
            parameter.Add(new SqlParameter("@IsDeleted", mark.IsDeleted));


            var result = await dbContext.Database
             .ExecuteSqlRawAsync(@"exec AddNewMarks @StudentID, @UnitID, @Mark, @Grade, @IsDeleted", parameter.ToArray());

            return result;
        }

        public async Task<int> UpdateMarksAsync(Marks mark)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@MarkID", mark.MarkID));
            parameter.Add(new SqlParameter("@StudentID", mark.StudentID));
            parameter.Add(new SqlParameter("@UnitID", mark.UnitID));
            parameter.Add(new SqlParameter("@Mark", mark.Mark));
            parameter.Add(new SqlParameter("@Grade", mark.Grade));

            var result = await dbContext.Database
            .ExecuteSqlRawAsync(@"exec UpdateMarks @MarkID, @StudentID, @UnitID, @Mark, @Grade", parameter.ToArray());
            return result;
        }

        public async Task<int> DeleteMarksAsync(int MarkID)
        {
            return await dbContext.Database.ExecuteSqlInterpolatedAsync($"DeleteMarksByID {MarkID}");
        }


        public async Task<int> EligibleCheckResult(Marks mark)
        {
            var param = new DynamicParameters();
            param.Add("@StudentID", mark.StudentID);
            int UnitCount = await _connection.ExecuteScalarAsync<int>("GetUnitFail", param);
            return UnitCount;
        }

        public async Task<int> EligibleCheckDuplicate(Marks mark)
        {
            var param = new DynamicParameters();
            param.Add("@StudentID", mark.StudentID);
            param.Add("@UnitID", mark.UnitID);
            int SameUnitCount = await _connection.ExecuteScalarAsync<int>("GetUnitExist", param);
            return SameUnitCount;
        }

        public async Task<int> EligibleCheckResultEdit(Marks mark)
        {
            var param = new DynamicParameters();
            param.Add("@StudentID", mark.StudentID);
            param.Add("@MarkID", mark.MarkID);
            int UnitCount = await _connection.ExecuteScalarAsync<int>("GetUnitFailEdit", param);
            return UnitCount;
        }

        public async Task<IEnumerable<MarkList>> FetchPaginatedMark(int pageNumber, int pageSize) //pagination
        {
            var param = new DynamicParameters();
            param.Add("@pageNumber", pageNumber);
            param.Add("@PageSize", pageSize);

            var result = await _connection.QueryAsync<MarkList>("GetMarkPagination", param, commandType: CommandType.StoredProcedure);
            return result;
        }

        public async Task<List<MarkList>> GetStudentUnitAvailable(int studentID)
        {
            var param = new DynamicParameters(); 
            param.Add("@StudentID", studentID); 
            var result = await _connection.QueryAsync<MarkList>("GetStudentUnitAvailable", param, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<int> GetTotalMark()
        {
            int TotalMarkCount = await _connection.ExecuteScalarAsync<int>("GetTotalMark");
            return TotalMarkCount;

        }

    }
}
