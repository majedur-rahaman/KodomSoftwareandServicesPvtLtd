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
    public class Patient
    {
        public int PatientId { set; get; }
        [Required(ErrorMessage = "Please provide your name")]
        [StringLength(50)]
        [DisplayName("Patient Name")]
        public string PatientName { set; get; }
        [Required(ErrorMessage = "Please fill up the patient age field")]
        [DisplayName("Patient Age")]
        public string PatientAge { set; get; }
        [Required(ErrorMessage = "Please fill up the E-Mail field")]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please provide a valid Mail address")]
        [Remote("CheckUniqueEmail", "Patient", ErrorMessage = "Email Already Exists!")]
        public string PatientEmail { set; get; }
        [Required(ErrorMessage = "Please provide your phone number")]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Phone Number")]
        public string PatientPhoneNumber { set; get; }
        [DisplayName("Address")]
        public string PatientAddress { set; get; }
        [Required(ErrorMessage = "Please provide user name")]
        [StringLength(50)]
        [DisplayName("User Name")]
        [Remote("CheckUniqueUserName", "Patient", ErrorMessage = "User Name Already Exists!")]
        public string UserName { set; get; }
        [Required(ErrorMessage = "Please provide password")]
        [StringLength(50)]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { set; get; }

        [ForeignKey("Gender")]
        [DisplayName("Gender")]
        public int GenderId { set; get; }
        [DisplayName("Gender")]
        public virtual Gender Gender { set; get; }
        [DisplayName("Image")]
        public string PatientImage { set; get; }
    }
}