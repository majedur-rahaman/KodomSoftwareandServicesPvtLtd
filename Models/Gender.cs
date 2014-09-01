using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Project_AutoSuggestion_E_AppointmentApp.Models
{
    public class Gender
    {
        public int GenderId { set; get; }
        [DisplayName("Gender")]
        public string GenderType { set; get; }
    }
}