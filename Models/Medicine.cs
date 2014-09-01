using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_AutoSuggestion_E_AppointmentApp.Models
{
    public class Medicine
    {
        [Key]
        public int MedicineId { get; set; }
        [Required(ErrorMessage = "Enter medicine name")]
        [Display(Name = "Medicine Name")]
        public string MedicineName { get; set; }

        [Required(ErrorMessage = "Enter medicine description")]
        [Display(Name = "Medicine Description")]
        [DataType(DataType.MultilineText)]
        public string MedicineDescription { get; set; }
        [Required(ErrorMessage = "Enter medicine type")]
        [Display(Name = "Medicine type")]
        public string MedicineType { get; set; }
        [Required(ErrorMessage = "Enter medicine rate")]
        [Display(Name = "Medicine Rate")]
        public string MedicineRate { get; set; }


    }
   
}