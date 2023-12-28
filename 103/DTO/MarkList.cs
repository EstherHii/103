using _103.Models;
using System.ComponentModel.DataAnnotations;

namespace _103.DTO
{
    public class MarkList
    {
        public int MarkID { get; set; }
        [Range(0, 100)]
        public int Mark { get; set; }
        public string Grade { get; set; }
        public bool IsDeleted { get; set; }

        [Display(Name = "Student ID")]
        public int StudentID { get; set; }

        [Display(Name = "Unit ID")]
        public int UnitID { get; set; }


        [Display(Name = "Unit Name")]
        public string? UnitName { get; set; }

        [Display(Name = "Student Name")]
        public string? StudentName { get; set; }

        public MarkList() { } //initializes 
        public MarkList(Marks mark)
        {
            MarkID = mark.MarkID;
            Mark = mark.Mark;
            Grade = mark.Grade;
            IsDeleted = mark.IsDeleted;
            StudentID = mark.StudentID;
            UnitID = mark.UnitID;
        }
    }



   

}
