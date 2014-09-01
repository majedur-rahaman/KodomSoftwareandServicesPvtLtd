using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_AutoSuggestion_E_AppointmentApp.Models;

namespace Project_AutoSuggestion_E_AppointmentApp.Controllers
{
    public class MedicineController:Controller
    {
       private  AppContext db=new AppContext();

        public ActionResult Index()
        {
            
         
            return View(db.MedicinEntries.ToList());
        }


        [HttpGet]
        public ActionResult Create()
        {

            return View();


        }

        [HttpPost]
        public ActionResult Create(Medicine aMedicine)
        {
      
            if (ModelState.IsValid)
            {
                if (aMedicine!=null)
                {
                    db.MedicinEntries.Add(aMedicine);
                    db.SaveChanges();
                    return RedirectToAction("Create");

                }
                
            }
            return RedirectToAction("Create");
        }
    }
}