using _103.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _103.Models
{
    public class Student
    {
        [Display(Name = "Student ID")]
        public int StudentID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Student Name")]
        [StringLength(50, ErrorMessage = "Name length can't exceed 50 characters")]
        [RegularExpression(@"^[\u4E00-\u9FFFa-zA-Z\s]+$", ErrorMessage = "{0} should contain only Chinese and English characters.")]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Student Email")]
        [StringLength(50, ErrorMessage = "Email length can't exceed 50 characters")]
       
        [RegularExpression(@"^\w+@\w+\.com$", ErrorMessage = "Please enter a valid email in the format: example@gmail.com")]
        public string StudentEmail { get; set; }
        public bool IsDeleted { get; set; }
    }
}
