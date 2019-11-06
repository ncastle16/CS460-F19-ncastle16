using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CS460HW5.Models
{
    public class Assignment
    {

        public static List<SelectListItem> Priority = new List<SelectListItem>()
        {
            new SelectListItem() {Text="High"},
            new SelectListItem() {Text="Medium"},
            new SelectListItem() {Text="Low"}
        };

        [Key]
        public int ID { get; set; }

        [Required, DisplayName("Priority Order")]
        public string PriorityOrder { get; set; }

        [Required, DisplayName("Due Time")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM-dd-yyyy}")]
        public DateTime DueDate { get; set; }

        [Required, DisplayName("Department")]
        public string Department { get; set; }

        [Required, DisplayName("Due Time")]
        [DataType(DataType.Time)]
        public DateTime DueTime { get; set; }
        
        [Required, DisplayName("Course ID")]
        public string CourseID { get; set; }

        [Required, DisplayName("Homework Title")]
        public string HomeworkTitle { get; set; }

        [DisplayName("Notes")]
        public string Notes { get; set; }
    }

}