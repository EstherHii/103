using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mime;
namespace _103.Models
{
    public class Marks
    {
        [Key]
        [Column(TypeName = "int")]
        [Display(Name = "Mark ID")]
        public int MarkID { get; set; }

        [Column(TypeName = "int")]
        public int Mark { get; set; }

        [Column(TypeName = "string")]
        [MaxLength(2)]
        public string? Grade { get; set; }

        public bool IsDeleted { get; set; }

        /*AddForeignKey*/
        [Display(Name = "Student ID")]
        public int StudentID { get; set; }
        public Student? Student { get; set; }

        [Display(Name = "Unit ID")]
        public int UnitID { get; set; }
        public Unit? Unit { get; set; }



        public void GenerateGrade()
        {
            if (Mark >= 90)
            {
                Grade = "A+";
            }
            else if (Mark >= 80)
            {
                Grade = "A";
            }
            else if (Mark >= 70)
            {
                Grade = "B";
            }
            else if (Mark >= 60)
            {
                Grade = "C";
            }
            else if (Mark >= 50)
            {
                Grade = "D";
            }
            else
            {
                Grade = "F";
            }
        }

    }

}
