using System.ComponentModel.DataAnnotations;

namespace _103.DTO
{
    public class UnitList
    {
        [Display(Name = "Unit ID")]
        public int UnitID { get; set; }

        [Display(Name = "Unit Name")] 
        public string UnitName { get; set; }

        [Display(Name = "Teacher Name")]
        public string TeacherName { get; set; }

        [Display(Name = "Teacher ID")]
        public int TeacherID{ get; set; }
        public DateTime Schedule { get; set; }

        public bool IsDeleted { get; set; }
    }
}
