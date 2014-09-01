using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_AutoSuggestion_E_AppointmentApp.Models;

namespace Project_AutoSuggestion_E_AppointmentApp.Controllers
{
    public class PatientController : Controller
    {
        private AppContext db = new AppContext();

        // GET: /Patient/
        public ActionResult Index()
        {
            var patients = db.Patients.Include(p => p.Gender);
            return View(patients.ToList());
        }

        // GET: /Patient/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Patient patient = db.Patients.Find(id);
        //    if (patient == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(patient);
        //}

        // GET: /Patient/Create
        public ActionResult Create()
        {
            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "GenderType");
            return View();
        }

        // POST: /Patient/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatientId,PatientName,PatientAge,PatientEmail,PatientPhoneNumber,PatientAddress,UserName,Password,GenderId,PatientImage")] Patient patient, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    image.SaveAs(HttpContext.Server.MapPath("~/Images/") + image.FileName);
                    patient.PatientImage = image.FileName;
                }
                db.Patients.Add(patient);
                db.SaveChanges();
                TempData["message"] = "Patient Registered Successfully. Use our service to be healthy";
                return RedirectToAction("Create");
            }

            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "GenderType", patient.GenderId);
            return View(patient);
        }

        // GET: /Patient/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Patient patient = db.Patients.Find(id);
        //    if (patient == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "GenderType", patient.GenderId);
        //    return View(patient);
        //}

        // POST: /Patient/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include="PatientId,PatientName,PatientAge,PatientEmail,PatientPhoneNumber,PatientAddress,UserName,Password,GenderId,PatientImage")] Patient patient)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(patient).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "GenderType", patient.GenderId);
        //    return View(patient);
        //}

        // GET: /Patient/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Patient patient = db.Patients.Find(id);
        //    if (patient == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(patient);
        //}

        // POST: /Patient/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Patient patient = db.Patients.Find(id);
        //    db.Patients.Remove(patient);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public JsonResult CheckUniqueEmail(string patientemail)
        {
            var result = db.Patients.Count(p => p.PatientEmail == patientemail) == 0;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckUniqueUserName(string username)
        {
            var result = db.Patients.Count(p => p.UserName == username) == 0;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
