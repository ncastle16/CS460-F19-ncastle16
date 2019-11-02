using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CS460HW5.Models
{
    public class Assignment
    {
        [Key]
        public int ID { get; set; }

        [Required, DisplayName("PriorityOrder")]
        public string PriorityOrder { get; set; }

        [Required, DisplayName("Due Date")]
        public DateTime DueDate { get; set; } 

        [Required, DisplayName("Department")]
        [StringLength(3)]
        public string Department { get; set; }

        [Required, DisplayName("Due Time")]
        public DateTime DueTime { get; set; }
        
        [Required, DisplayName("Course ID")]
        public string CourseID { get; set; }

        [Required, DisplayName("Homework Title")]
        public string HomeworkTitle { get; set; }

        [Required, DisplayName("Notes")]
        public string Notes { get; set; }
    }
    public enum PriorityOrder
    {
        High,
        Medium,
        Low
    }
}