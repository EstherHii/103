using _103.Data;
using _103.IRepository;
using _103.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace _103.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly UniDbContext dbContext;
        private readonly IDbConnection _connection;


        public TeacherRepository(UniDbContext dbContext)
        {
            this.dbContext = dbContext;
            _connection = dbContext._connection;
        }

        public async Task<List<Teacher>> GetTeacherListAsync()
        {
            IEnumerable<Teacher> result = await _connection.QueryAsync<Teacher>("GetTeacherList", commandType: CommandType.StoredProcedure);
            return result.ToList(); 
        }

        public async Task<Teacher> GetTeacherByIdAsync(int TeacherID)
        {
            var param = new DynamicParameters();
            param.Add("@TeacherID", TeacherID);

            var result = await _connection.QueryAsync<Teacher>("GetTeacherByID", param, commandType: CommandType.StoredProcedure);
            var TeacherDetails = result.FirstOrDefault();

            return TeacherDetails;      
        }

        public async Task<int> AddTeacherAsync(Teacher teachers)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@TeacherName", teachers.TeacherName));
            parameter.Add(new SqlParameter("@IsDeleted", teachers.IsDeleted));

            var result = await dbContext.Database
             .ExecuteSqlRawAsync(@"exec AddNewTeacher @TeacherName,  @IsDeleted", parameter.ToArray());

            return result;
        }

        public async Task<int> UpdateTeacherAsync(Teacher teachers)
        {
            var parameter = new List<SqlParameter>();
             parameter.Add(new SqlParameter("@TeacherID", teachers.TeacherID));
            parameter.Add(new SqlParameter("@TeacherName", teachers.TeacherName));

            var result = await dbContext.Database
            .ExecuteSqlRawAsync(@"exec UpdateTeacher @TeacherID, @TeacherName", parameter.ToArray());
            return result;
        }

        public async Task<int> DeleteTeacherAsync(int TeacherID)
        {
            return await dbContext.Database.ExecuteSqlInterpolatedAsync($"DeleteTeacherByID {TeacherID}");
        }

        public async Task<IEnumerable<Teacher>> FetchPaginatedTeacher(int pageNumber, int pageSize) //pagination
        {
            var param = new DynamicParameters();
            param.Add("@pageNumber", pageNumber);
            param.Add("@PageSize", pageSize);

            var result = await _connection.QueryAsync<Teacher>("GetTeacherPagination", param, commandType: CommandType.StoredProcedure);
            return result;
        }

        public async Task<int>GetTotalTeacher()
        {
            int TotalTeacherCount = await _connection.ExecuteScalarAsync<int>("GetTotalTeacher");
            return TotalTeacherCount;
        }

    }
}

