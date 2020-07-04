using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UniversidadContoso.DAL;
using UniversidadContoso.Models;
using System.Data.Entity;

namespace UniversidadContoso.Controllers
{
    public class CursoController : Controller
    {
        
        static List<Curso> Cursos = new List<Curso>();
        private ContosoContext ContosoCont = new ContosoContext();
        //-------------------------------------VISTAS-------------------------------------//
        public ActionResult ListaCursos()
        {
            
            Cursos = ContosoCont.Cursoo.ToList();
            if (Cursos == null)
            {
                Cursos = new List<Curso>();
            }
            else
            {
                Cursos = ContosoCont.Cursoo.Include(c => c.Departamento).Include(c => c.Instructor).Include(c => c.Alumno).ToList();
            }
            if (Session["Matriculado"] == null)
            {
                Session["Matriculado"] = false;
            }

            ViewBag.Inscripto = Session["Matriculado"];
            Session["Matriculado"] = false;

            return View(Cursos);
        }
        public ActionResult AgregarCurso()
        {
            ViewBag.Departamentos = ContosoCont.Departamentoo.ToList();
            ViewBag.Instructores = ContosoCont.Instructoor.ToList();
            return View();
        }
        public ActionResult EditarCurso(int Id)
        {
            ViewBag.Instructores = ContosoCont.Instructoor.ToList();

            Curso CursoFiltrado = ContosoCont.Cursoo.Include(c => c.Departamento).Include(c => c.Instructor).Where(c => c.ID_Curso == Id).FirstOrDefault();

            return View(CursoFiltrado);
        }
        
        //-------------------------------------ACCIONES-------------------------------------//
        public ActionResult CrearCurso([Bind(Include = "ID_Curso,Titulo_Curso,DepartamentoID_Depto,InstructorID_Instructor,Capacidad_Curso")] Curso curso)
        {
            Cursos = ContosoCont.Cursoo.ToList();

            if (Cursos == null)
            {
                Cursos = new List<Curso>();
            }
            
            ContosoCont.Cursoo.Add(curso);
            ContosoCont.SaveChanges();

            return RedirectToAction("ListaCursos");
        }
        public ActionResult ModificarCurso([Bind(Include = "ID_Curso,InstructorID_Instructor,Capacidad_Curso")] Curso curso)
        {
            Cursos = ContosoCont.Cursoo.ToList();

            if (Cursos == null)
            {
                Cursos = new List<Curso>();
            }

            var CursoExistente = Cursos.Where(c => c.ID_Curso == curso.ID_Curso).FirstOrDefault();

            if (CursoExistente != null)
            {
                
                CursoExistente.InstructorID_Instructor = curso.InstructorID_Instructor;
                CursoExistente.Capacidad_Curso = curso.Capacidad_Curso;
            }

            ContosoCont.SaveChanges();

            return RedirectToAction("ListaCursos");
        }
        public ActionResult EliminarCurso(UniversidadContoso.Models.Curso curso)
        {
            var CursoDelete = ContosoCont.Cursoo.ToList().Find(d => d.ID_Curso == curso.ID_Curso);
            ContosoCont.Cursoo.Remove(CursoDelete);
            ContosoCont.SaveChanges();
            return RedirectToAction("ListaCursos");
        }
        public ActionResult AgregarMatricula(FormCollection form)
        {
            var Alumno = new Alumno();
            Alumno.Nombre_Alumno = form["Nombre_Alumno"];
            Alumno.Email_Alumno = form["Email_Alumno"];


            int IdCurso = int.Parse(form["ID_Curso"]);

            var CursoInscripto = ContosoCont.Cursoo.Include(c => c.Alumno).Where(c => c.ID_Curso == IdCurso).FirstOrDefault();

            CursoInscripto.Alumno.Add(Alumno);
            ContosoCont.SaveChanges();

            Session["Matriculado"] = true;

            return RedirectToAction("ListaCursos");
        }
        public ActionResult SearchCurso(string searchCursos)
        {
            var cont = ContosoCont.Cursoo;
            var res = cont.Where(x => x.Titulo_Curso.Contains(searchCursos) || searchCursos == null).ToList();
            return View("ListaCursos", res);
        }
        
    }
}
