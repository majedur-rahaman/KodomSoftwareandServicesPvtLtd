using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Project_AutoSuggestion_E_AppointmentApp.Models;

namespace Project_AutoSuggestion_E_AppointmentApp.Controllers
{
    public class AppContext:DbContext
    {
        public DbSet<Patient> Patients { set; get; }

        public DbSet<Gender> Genders { set; get; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Designation> Designations { set; get; }

        public DbSet<Doctor> Doctors { set; get; }

        public DbSet<Article> Articles { set; get; }
        public DbSet<Medicine> MedicinEntries { get; set; } 
    }
}