using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_AutoSuggestion_E_AppointmentApp.Models
{
    public class Department
    {
        public int DepartmentId { set; get; }
        [Required(ErrorMessage = "Please provide department name")]
        [StringLength(50)]
        [DisplayName("Department Name")]
        [Remote("CheckUniqueDepartment", "Department", ErrorMessage = "Please enter an unique department")]
        public string DepartmentName { set; get; }
        [DataType(DataType.MultilineText)]
        [DisplayName("Description")]
        public string DepartmentDescription { set; get; }
    }
}