using _103.Models;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace _103.DTO
{
    public class StudentList
    {
        
        public bool IsDeleted { get; set; }
        public int StudentID { get; set; }

        [Display(Name = "Student Name")]
        public string StudentName { get; set; }

        [Display(Name = "Student Email")]
        public string StudentEmail { get; set; }

        public List<MarkList> marks = new();
        public StudentList(Student student)
        {
            IsDeleted = student.IsDeleted;
            StudentID = student.StudentID;  
            StudentName = student.StudentName;
            StudentEmail = student.StudentEmail;
        }
    }


}



/*        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
*/
// Navigation property to Marks
 







