using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace _103.Models
{
    public class Teacher
    {
        [Display(Name = "Teacher ID")]
        public int TeacherID { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, ErrorMessage = "{0} can't exceed 50 characters")]
        [Display(Name = "Teacher Name")]
        [RegularExpression(@"^[\u4E00-\u9FFFa-zA-Z\s]+$", ErrorMessage = "{0} should contain only Chinese and English characters.")]

        // \u4E00-\u9FFF: Start-End of HanScript
        // \s: space
        // +: Requires one or more occurrences of the preceding pattern.
        // $: endofstring
        public string TeacherName { get; set; }
        public bool IsDeleted { get; set; }

    }
}
