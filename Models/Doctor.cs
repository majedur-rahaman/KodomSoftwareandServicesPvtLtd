using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_AutoSuggestion_E_AppointmentApp.Models
{
    public class Doctor
    {
        public int DoctorId { set; get; }
        [Required(ErrorMessage = "Please provide your name")]
        [StringLength(50)]
        [DisplayName("Doctor Name")]
        public string DoctorName { set; get; }

        [Required(ErrorMessage = "Please fill up the E-Mail field")]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please provide a valid Mail address")]
        [Remote("CheckUniqueEmail", "Doctor", ErrorMessage = "Email Already Exists!")]
        public string DoctorEmail { set; get; }

        [Required(ErrorMessage = "Please provide your phone number")]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Phone Number")]
        public string DoctorPhoneNumber { set; get; }

        [DisplayName("Location")]
        [DataType(DataType.MultilineText)]
        public string DoctorLocation { set; get; }

        [Required(ErrorMessage = "Please provide the information")]
        [DisplayName("Degree")]
        public string DoctorDegree { set; get; }

        [Required(ErrorMessage = "Please provide your designation")]
        [DisplayName("Designation")]
        public int? DesignationId { set; get; }

        public virtual Designation Designation { set; get; }


        [Required(ErrorMessage = "Please provide user name")]
        [StringLength(50)]
        [DisplayName("User Name")]
        [Remote("CheckUniqueUserName", "Doctor", ErrorMessage = "User Name Already Exists!")]
        public string UserName { set; get; }
        
        [Required(ErrorMessage = "Please provide password")]
        [StringLength(50)]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { set; get; }

        [Required(ErrorMessage = "Please provide the information about fee")]
        [DisplayName("Fee")]
        public double DoctorFee { set; get; }

        [Required(ErrorMessage = "Please fill up the Experience field")]
        [DisplayName("Experience")]
        public double DoctorExperience { set; get; }

        [ForeignKey("Department")]
        [Required(ErrorMessage = "Please provide from which department you are from")]
        [DisplayName("Department")]
        public int? DepartmentId { set; get; }

        public virtual Department Department { set; get; }


        [DisplayName("Image")]
        public string DoctorImage { set; get; }
    }
}