using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversidadContoso.DAL;
using UniversidadContoso.Models;

namespace UniversidadContoso.Controllers
{
    public class InstructorController : Controller
    {
        static List<Instructor> Instructores = new List<Instructor>();
        private ContosoContext ContosoCont = new ContosoContext();

        // GET: Instructor
        public ActionResult ListaInstructores()
        {
            Instructores = ContosoCont.Instructoor.ToList();

            if (Instructores == null)
            {
                Instructores = new List<Instructor>();
            }

            return View(Instructores);
        }
        public ActionResult AgregarInstructores()
        {
            return View();
        }
        public ActionResult EditarInstructores(int Id)
        {
            Instructor InstructorFiltrado = ContosoCont.Instructoor.Where(c => c.ID_Instructor == Id).FirstOrDefault();
            return View(InstructorFiltrado);
        }
        [HttpPost]
        public ActionResult CrearInstructor(FormCollection form)
        {
            Instructores = ContosoCont.Instructoor.ToList();
            if (Instructores == null)
            {
                Instructores = new List<Instructor>();
            }
            
            var instructor = new Instructor();
            instructor.Nombre_Instructor = form["Nombre_Instructor"];
            instructor.DiaContrato_Instructor = form["DiaContrato_Instructor"];

            ContosoCont.Instructoor.Add(instructor);
            ContosoCont.SaveChanges();

            return RedirectToAction("ListaInstructores");
        }
        public ActionResult EditarInstructor(FormCollection form)
        {
            Instructores = ContosoCont.Instructoor.ToList();

            if (Instructores == null)
            {
                Instructores = new List<Instructor>();
            }
            
            var instructorM = new Instructor();
            instructorM.Nombre_Instructor = form["Nombre_Instructor"];
            instructorM.DiaContrato_Instructor = form["DiaContrato_Instructor"];

            var editInstructor = Instructores.Where(i => i.ID_Instructor == int.Parse(form["ID_Instructor"])).FirstOrDefault();

            if (editInstructor != null)
            {
                editInstructor.Nombre_Instructor = instructorM.Nombre_Instructor;
                editInstructor.DiaContrato_Instructor = instructorM.DiaContrato_Instructor;
            }
            ContosoCont.SaveChanges();

            return RedirectToAction("ListaInstructores");
        }
        public ActionResult EliminarInstructor(int id)
        {
            var InstructorDelete = ContosoCont.Instructoor.ToList().Find(d => d.ID_Instructor == id);
            ContosoCont.Instructoor.Remove(InstructorDelete);
            ContosoCont.SaveChanges();
            return RedirectToAction("ListaInstructores");
        }
        public ActionResult SearchInstructor(string SearchInstructor)
        {
            var cont = ContosoCont.Instructoor;
            var res = cont.Where(x => x.Nombre_Instructor.Contains(SearchInstructor) || SearchInstructor == null).ToList();
            return View("ListaInstructores", res);
        }
    }
}
