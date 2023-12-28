using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace _103.Models
{
    public class Unit
    {
        [Key]
        [Display(Name = "Unit ID")]
        public int UnitID { get; set; }


        [Display(Name = "Unit Name")]
        public string UnitName { get; set; }

        [Required]
        //[Column(TypeName = "Datetime")]
        [DisplayFormat(DataFormatString = "{0:yyyy/mm/dd}", ApplyFormatInEditMode = true)]

        public DateTime Schedule { get; set; }

        /*[ForeignKey("Teacher")]*/
        [Range (1,999999, ErrorMessage ="Please make sure your ID is correct.")]
        [Display(Name = "Teacher ID")]
        public int TeacherID { get; set; }
        public Teacher? Teacher { get; set; }

        public bool IsDeleted { get; set; }
    }
}

