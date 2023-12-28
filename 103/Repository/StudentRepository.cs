using _103.Data;
using _103.IRepository;
using _103.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using _103.DTO;

namespace _103.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly UniDbContext dbContext;
        private readonly IDbConnection _connection;


        public StudentRepository(UniDbContext dbContext)
        {
            this.dbContext = dbContext;
            _connection = dbContext._connection;
        }

        public async Task<List<Student>> GetStudentListAsync()
        {
            IEnumerable <Student> result = await _connection.QueryAsync<Student>("GetStudentList", commandType: CommandType.StoredProcedure);
            return result.ToList(); 
        }

        public async Task<Student> GetStudentByIdAsync(int StudentID)
        {
            var param = new DynamicParameters();
            param.Add("@StudentID", StudentID);
            //Get student list
            var result = await _connection.QueryAsync<Student>("GetStudentByID", param, commandType: CommandType.StoredProcedure);
            var StudentDetails = result.FirstOrDefault();
            //Filter studentid, singleordefault is find the unique data, ur student id is unique value
            // otherwise u cant use FirstOrDefault
            return StudentDetails;
        }
        public async Task<int> AddStudentAsync(Student students)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@StudentName", students.StudentName));
            parameter.Add(new SqlParameter("@StudentEmail", students.StudentEmail));
            parameter.Add(new SqlParameter("@IsDeleted", students.IsDeleted));

            var result = await dbContext.Database
             .ExecuteSqlRawAsync(@"exec AddNewStudent @StudentName, @StudentEmail, @IsDeleted", parameter.ToArray());
            return result;
        }

        public async Task<int> UpdateStudentAsync(Student students)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@StudentID", students.StudentID));
            parameter.Add(new SqlParameter("@StudentName", students.StudentName));
            parameter.Add(new SqlParameter("@StudentEmail", students.StudentEmail));

            var result = await dbContext.Database
            .ExecuteSqlRawAsync(@"exec UpdateStudent @StudentID, @StudentName, @StudentEmail", parameter.ToArray());
            return result;
        }

        public async Task<int> DeleteStudentAsync(int StudentID)
        {
           return await dbContext.Database.ExecuteSqlInterpolatedAsync($"DeleteStudentByID {StudentID}");
        }

        public async Task<int>DuplicateEmailCheck(Student students)
        {
            var param = new DynamicParameters();
            param.Add("@StudentEmail", students.StudentEmail);
            int SameEmailCount = (int)await _connection.ExecuteScalarAsync("CheckEmailDuplicate", param);
            return SameEmailCount;
        }

        //get mark by calling studentid 
        public async Task<StudentList> GetStudentResultByID(int StudentID)
        {
            Student student = await GetStudentByIdAsync(StudentID); //store student all info thru its id from db
            StudentList studentList = new (student);  //store in studentlist

            var param = new DynamicParameters(); //bigger storage
            param.Add("@StudentID", StudentID);
            //Data type <data> ListName
            //List of <Marks> fill in bigger form
            IEnumerable<MarkList> StudentResultDetails = await _connection.QueryAsync<MarkList>("GetStudentResultByID", param, commandType: CommandType.StoredProcedure);
           //throw inside studentlist.mark
            studentList.marks = StudentResultDetails.ToList();
            return studentList;
        }

        //pagination
        // Fetch paginated data from the database using your SQL query
        public async Task<IEnumerable<Student>> FetchPaginatedStudent(int pageNumber, int pageSize)
        {
            var param = new DynamicParameters();
            param.Add("@PageSize", pageSize);
            param.Add("@pageNumber", pageNumber);

            var result = await _connection.QueryAsync<Student>("GetStudentPagination", param, commandType: CommandType.StoredProcedure);

            return result; 
        }

        public async Task<int> GetTotalStudent()
        {
            int TotalStudentCount = await _connection.ExecuteScalarAsync<int>("GetTotalStudent");
            return TotalStudentCount;
        }
    }
}
